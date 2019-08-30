using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using Quartz;
using System;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.QuartzScheduling.USPowerball
{
    /// <summary>
    /// Job creation for US Powerball to be executed by Quartz when triggered.
    /// </summary>
    public class USPowerballJob : IJob
    {
        /// <summary>
        /// Task that gets executed for US Powerball when triggered by Quartz.net
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            ILotteryScrape lotteryScrape = ScrapeAndQuartzFactory.CreateLotto649Scrape();
            // TODO: Better logging.
            Console.WriteLine($"{DateTime.Now} : Starting US Powerball Scrape");
            await lotteryScrape.ScrapeLotteryAsync();
        }
    }
}
