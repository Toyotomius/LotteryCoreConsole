using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public interface ILotto649Scrape
    {
        Task  ScrapeLotto649Async();
        Task<IWebDriver> CreateDriverAsync();
    }
}