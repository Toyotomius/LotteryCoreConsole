using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using Quartz;
using System;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.QuartzScheduling.Lotto649
{
    /// <summary>
    /// Job creation for Lotto649 to be executed by Quartz when triggered.
    /// </summary>
    public class Lotto649Job : IJob
    {
        /// <summary>
        /// Task that gets executed for Lotto649 when triggered by Quartz.net
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            ILotteryScrape lotteryScrape = ScrapeAndQuartzFactory.CreateLotto649Scrape();
            // TODO: Better logging.
            Console.WriteLine($"{DateTime.Now} : Starting Lotto649 Scrape");
            await lotteryScrape.ScrapeLotteryAsync();
        }
    }
}
