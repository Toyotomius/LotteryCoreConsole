using OpenQA.Selenium;

using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface ILotto649Scrape
    {
        Task<IWebDriver> CreateDriverAsync();

        Task ScrapeLotto649Async();
    }
}