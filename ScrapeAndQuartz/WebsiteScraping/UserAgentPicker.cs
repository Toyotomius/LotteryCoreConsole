using System;
using System.IO;
using System.Threading.Tasks;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public class UserAgentPicker : IUserAgentPicker
    {
        private readonly Random _rand;

        public UserAgentPicker(Random rand)
        {
            _rand = rand;
        }

        public async Task<string> RandomUserAgentAsync()
        {
            string[] uAgentsArray = File.ReadAllLines("./Data Files/useragents.txt");

            Task<string> randomAgentTask = Task.FromResult(uAgentsArray[_rand.Next(uAgentsArray.Length)]);

            return await randomAgentTask;
        }
    }
}