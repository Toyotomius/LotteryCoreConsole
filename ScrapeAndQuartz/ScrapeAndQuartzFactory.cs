using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using System;

namespace LotteryCoreConsole.ScrapeAndQuartz
{
    /// <summary>
    /// Factory for creating all instances needed in the webscraping / Quartz portion of the program.
    /// </summary>
    public static class SCrapeAndQuartzFactory
    {
        public static IWebsiteScraping CreateWebsiteScraping()
        {
            return new WebsiteScraping.WebsiteScraping(CreateUserAgentPicker());
        }

        public static IFormatNewLotteryResult CreateFormatNewLotteryResult()
        {
            return new FormatNewLotteryResult();
        }

        public static ILotteryScrape CreateLotto649Scrape()
        {
            return new Lotto649Scrape(CreateWebsiteScraping(), CreateFormatNewLotteryResult(),
                CreateWriteNewLottoResult());
        }

        public static IWebsiteScraping CreateWebSiteScraping()
        {
            return new WebsiteScraping.WebsiteScraping(CreateUserAgentPicker());
        }

        public static IWriteNewLottoResult CreateWriteNewLottoResult()
        {
            return new WriteNewLottoResult();
        }

        private static Random CreateRandom()
        {
            return new Random();
        }

        private static IUserAgentPicker CreateUserAgentPicker()
        {
            return new UserAgentPicker(CreateRandom());
        }
    }
}