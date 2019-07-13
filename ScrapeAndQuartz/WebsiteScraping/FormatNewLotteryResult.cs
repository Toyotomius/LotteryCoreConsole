using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

using System;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public class FormatNewLotteryResult : IFormatNewLotteryResult
    {
        public async Task<string> FormatResult(string winningNumbers)
        {
            // Website scrape happens early the next day, so we find the previous day (day of the draw) and format it.
            var yesterday = DateTime.Now.AddDays(-1).ToString("ddd, MMM dd, yyy");
            var resultTask = Task.Run(() => "\n    {\n" + $"      \"Date\" : \"{yesterday}\",\n" +
                                            $"      \"Numbers\" : [{winningNumbers}]" + "\n    },");
            return await resultTask;
        }
    }
}