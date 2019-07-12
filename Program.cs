using LotteryCoreConsole.Lottery_Calculation.Interfaces;
using LotteryCoreConsole.ScrapeAndQuartz;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;

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
                ILotto649Scrape lotto649Scrape = SCrapeAndQuartzFactory.CreateLotto649Scrape();
                await lotto649Scrape.ScrapeLotto649Async();
            }
            // Task scheduler chain for specific lotteries.
            //SchdTask schd = new SchdTask();
            //schd.Schedule();
            //while (true)
            //{
            //}

            //Console.ReadKey();

            //(List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo = (lotteryFile, lotteryJObject);

            //IBeginLottoCalculations beginCalc = Factory.CreateBeginLottoCalculations();
            //await beginCalc.LottoChain(lotteryInfo);
        }
    }
}

// TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
// TODO: Clean up logfile at various points.
// TODO: Dependency Injection.
// TODO: Sanity checks. All the sanity. It's currently without any ability to remain sane.
// TODO: Add some sort of ability to pick out frequency based on a range of dates.