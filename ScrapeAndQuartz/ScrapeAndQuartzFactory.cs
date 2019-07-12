using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

using System;

namespace LotteryCoreConsole.ScrapeAndQuartz
{
    public static class SCrapeAndQuartzFactory
    {
        public static ILotto649Scrape CreateLotto649Scrape()
        {
            return new Lotto649Scrape(CreateUserAgentPicker());
        }

        public static IWebsiteScraping CreateWebSiteScraping()
        {
            return new WebsiteScraping.WebsiteScraping(CreateUserAgentPicker());
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