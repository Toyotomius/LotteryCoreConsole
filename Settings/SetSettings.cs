using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Settings
{
    public class SetSettings : ISetSettings
    {
        private readonly ILogging _logger;
        private readonly ISettings _settings;
        private List<JObject> _lotteryJObject;

        public SetSettings(ISettings settings, ILogging logger)
        {
            _settings = settings;
            _logger = logger;
        }

        private List<string> LotteryFile { get; set; }

        public async Task<(List<string> LotteryFile, List<JObject> LotteryJObject, bool scrapeWebsites)>
            ApplySettingsAsync()
        {
            Task<JObject> settingsFromFileTask = _settings.ReadSettings();
            JObject settingsFromFile = await settingsFromFileTask;

            //TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
            // TODO: Clean up logfile at various points.

            LotteryFile = new List<string>();
            _lotteryJObject = new List<JObject>();

            // Checks for True/False for scraping websites on first run. If true, sets up Quartz timers to scrape new
            // winning numbers automatically.
            var scrapeWebsites = settingsFromFile["ScrapeLotteryWebsites"].ToObject<bool>();

            // Takes each item from the array of json lottery files and adds it to a list
            foreach (JToken itm in settingsFromFile["LotteryMasterFiles"]) LotteryFile.Add(itm.ToString());

            // Descending for loop to allow for removing any files that are not present while logging such.
            for (int i = LotteryFile.Count - 1; i >= 0; i--)
                try
                {
                    // tries to create list of json objects from the contents of the file from config
                    _lotteryJObject.Add(JObject.Parse(File.ReadAllText($"./Data Files/{LotteryFile[i]}")));
                }
                catch (Exception) when (!File.Exists($"./Data Files/{LotteryFile[i]}"))
                {
                    _logger.Log($"{DateTime.Now} : " +
                                $"File \"{LotteryFile[i]}\" Does Not Exist. Verify the folder location & is correctly named in the config.\n" +
                                "    * Check the config.json file for proper format.");

                    LotteryFile.Remove(LotteryFile[i]);
                }
                catch (JsonReaderException)
                {
                    _logger.Log($"{DateTime.Now} : " +
                                $"File \"{LotteryFile[i]}\" Is not a valid Json file.\n" +
                                "    * Check the config.json file for proper format.");
                    LotteryFile.Remove(LotteryFile[i]);
                }

            // Reverses list to compensate for descending for loop
            _lotteryJObject.Reverse();
            return (LotteryFile, _lotteryJObject, scrapeWebsites);
        }
    }
}