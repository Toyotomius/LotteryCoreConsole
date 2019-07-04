using System;
using System.Collections.Generic;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;
using LotteryCoreConsole.ScrapeAndQuartz;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping;
using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole
{
    internal static class Program
    {
        private static async System.Threading.Tasks.Task Main()
        {
            IGetSettings set = Factory.CreateGetSettings();
            (List<string> lotteryFile, List<JObject> lotteryJObject, bool scrapeWebsites) = await set.RetrieveSettings();

            if (scrapeWebsites)
            {
                Console.WriteLine("ScrapeWebsites = True");
                IWebsiteScraping websiteScraping = SCrapeAndQuartzFactory.CreateWebSiteScraping();
                await websiteScraping.ScrapeAsync();
            }
            // Task scheduler chain for specific lotteries.
            //SchdTask schd = new SchdTask();
            //schd.Schedule();
            //while (true)
            //{
            //}



            //Console.ReadKey();

            (List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo = (lotteryFile, lotteryJObject);
            // TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
            // TODO: Clean up logfile at various points.

            IBeginLottoCalculations beginCalc = Factory.CreateBeginLottoCalculations();
            beginCalc.LottoChain(lotteryInfo);

            // First time run separated out for easier future expansion.
        }
    }
}

// TODO: Dependency Injection.
// TODO: Sanity checks. All the sanity. It's currently without any ability to remain sane.
// TODO: Add some sort of ability to pick out frequency based on a range of dates.
// TODOCompleted: Set up a while:true as a test with a decent sleep for on-the-fly settings change with a new lotto file.