using System;

using LotteryCoreConsole.WebsiteScraping.Interfaces;

namespace LotteryCoreConsole.WebsiteScraping
{
    public static class ScrapeSchedFactory
    {
        public static IUserAgentPicker CreateUserAgentPicker()
        {
            return new UserAgentPicker(CreateRandom());
        }

        public static IWebsiteScraping CreateWebSiteScraping()
        {
            return new WebsiteScraping(CreateUserAgentPicker());
        }

        private static Random CreateRandom()
        {
            return new Random();
        }
    }
}