using LotteryCoreConsole.Interfaces;

namespace LotteryCoreConsole
{
    internal static class Program
    {
        private static async System.Threading.Tasks.Task Main()
        {
            // Task scheduler chain for specific lotteries.
            //SchdTask schd = new SchdTask();
            //schd.Schedule();
            //while (true)
            //{
            //}

            //WebsiteScraping ws = new WebsiteScraping();
            //ws.Scrape();

            //Console.ReadKey();

            // First time run separated out for easier future expansion.
            IBeginLottoCalculations beginLottoCalculations = Factory.CreateStartLottoLists();
            await beginLottoCalculations.StartLottoListsAsync();
        }
    }
}

// TODO: Dependency Injection.
// TODO: Sanity checks. All the sanity. It's currently without any ability to remain sane.
// TODO: Add some sort of ability to pick out frequency based on a range of dates.
// TODOCompleted: Set up a while:true as a test with a decent sleep for on-the-fly settings change with a new lotto file.