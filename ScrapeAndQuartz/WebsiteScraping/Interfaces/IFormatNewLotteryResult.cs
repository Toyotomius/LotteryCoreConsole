using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface IFormatNewLotteryResult
    {
        Task<string> FormatResult(string winningNumbers, string bonusNumber);
    }
}
