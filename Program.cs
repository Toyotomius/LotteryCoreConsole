using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;
using LotteryCoreConsole.ScrapeAndQuartz;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole
{
    internal static class Program
    {
        private static async Task Main()
        {
            IGetSettings set = Factory.CreateGetSettings();
            (List<string> lotteryFile, List<JObject> lotteryJObject, bool scrapeWebsites) =
                await set.RetrieveSettings();


            if (scrapeWebsites)
            {
                Console.WriteLine("ScrapeWebsites = True");
                ILotteryScrape lotto649Scrape = SCrapeAndQuartzFactory.CreateLotto649Scrape();
                await lotto649Scrape.ScrapeLotteryAsync();
            }

            //while (true)
            //{
            //}
            // Task scheduler chain for specific lotteries.
            //SchdTask schd = new SchdTask();
            //schd.Schedule();
            //while (true)
            //{
            //}

            //Console.ReadKey();

            (List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo = (lotteryFile, lotteryJObject);

            IValidateLottoLists validateLists = Factory.CreateValidateLottoLists();
            await validateLists.ValidateLotteryLists(lotteryInfo);
        }
    }
}

// TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
// TODO: Clean up logfile at various points.
// TODO: Dependency Injection.
// TODO: Sanity checks. All the sanity. It's currently without any ability to remain sane.
// TODO: Add some sort of ability to pick out frequency based on a range of dates.