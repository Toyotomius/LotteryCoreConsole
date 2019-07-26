using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface ILotteryScrape
    {
        Task ScrapeLotteryAsync();
    }
}