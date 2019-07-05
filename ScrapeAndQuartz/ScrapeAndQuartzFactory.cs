﻿using System;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

namespace LotteryCoreConsole.ScrapeAndQuartz
{
    public static class SCrapeAndQuartzFactory
    {
        
        private static IUserAgentPicker CreateUserAgentPicker()
        {
            return new UserAgentPicker(CreateRandom());
        }

        public static IWebsiteScraping CreateWebSiteScraping()
        {
            return new WebsiteScraping.WebsiteScraping(CreateUserAgentPicker());
        }

        private static Random CreateRandom()
        {
            return new Random();
        }
    }
}