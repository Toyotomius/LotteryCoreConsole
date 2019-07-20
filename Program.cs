using System;
using System.Threading.Tasks;
using LotteryCoreConsole.ScrapeAndQuartz;

namespace LotteryCoreConsole
{
    internal static class Program
    {
        private static async Task Main()
        {
            var set = Factory.CreateGetSettings();
            var (lotteryFile, lotteryJObject, scrapeWebsites) = await set.RetrieveSettings();


            if (scrapeWebsites)
            {
                Console.WriteLine("ScrapeWebsites = True");
                var lotto649Scrape = SCrapeAndQuartzFactory.CreateLotto649Scrape();
                await lotto649Scrape.ScrapeLotto649Async();
            }

            while (true)
            {
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