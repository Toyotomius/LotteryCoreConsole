using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface IUserAgentPicker
    {
        Task<string> RandomUserAgentAsync();
    }
}