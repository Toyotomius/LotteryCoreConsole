using System;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface IWriteNewLottoResult
    {
        /// <summary>
        ///     Takes the new scraped lottery data, inserts it into the existing file at the top and writes the new file.
        /// </summary>
        /// <param name="lotteryName"></param>
        /// <param name="newResults"></param>
        /// <returns></returns>
        Task WriteNewResults(string lotteryName, string newResults);

        event EventHandler<LottoEventArgs> NewLotteryResultsWritten;
    }
}