using System;
using System.IO;
using LotteryCoreConsole.WebsiteScraping.Interfaces;

namespace LotteryCoreConsole.WebsiteScraping
{
    public static class ScrapeSchedFactory
    {
        
        private static IUserAgentPicker CreateUserAgentPicker()
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