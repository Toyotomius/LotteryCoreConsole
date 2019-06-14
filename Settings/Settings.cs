using System;
using System.IO;
using System.Threading.Tasks;
using LotteryCoreConsole.Interfaces;
using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Settings
{
    public class Settings : ISettings
    {
        //TODO: All the things here. All of 'em.

        private string _configContents;

        private string ConfigContents
        {
            set
            {
                if (new FileInfo("config.json").Length == 0)
                {
                    throw new Exception("config.json Found -- but it's empty!" +
                                        "\nFile should contain json structure & object named \"LotteryMasterFiles\"");
                }
                else if (File.ReadAllText("config.json").IndexOf("LotteryMasterFiles", StringComparison.Ordinal) == -1)
                {
                    throw new Exception(
                        "\"LotteryMasterFiles\" Not Found. Verify it's spelled correctly and is a proper json object.");
                }
                else
                {
                    _configContents = value;
                }
            }
        }

        // Pulls settings from the config file.
        public async Task<JObject> GetSettings()
        {
            ConfigContents = File.ReadAllText("config.json");
            Task<JObject> task = Task.FromResult(JObject.Parse(_configContents));
            JObject settings = await task;

            return settings;
        }
    }
}