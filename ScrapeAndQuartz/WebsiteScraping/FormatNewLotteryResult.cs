using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using System;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    /// <summary>
    ///     Takes the new results, finds the draw date and formats the new file to be used.
    /// </summary>
    public class FormatNewLotteryResult : IFormatNewLotteryResult
    {
        public async Task<string> FormatResult(string winningNumbers, string bonusNumber)
        {
            // Website scrape happens early the next day, so we find the previous day (day of the draw) and format it.
            var yesterday = DateTime.Now.AddDays(-1).ToString("ddd, MMM dd, yyy");
            var resultTask = Task.Run(() => "\n    {\n" + $"      \"Date\" : \"{yesterday}\",\n" +
                                                     $"      \"Numbers\" : [ {winningNumbers} ],\n" +
                                                     $"      \"Bonus\" : {bonusNumber}" + "\n    },");
            return await resultTask;
        }
    }
}
