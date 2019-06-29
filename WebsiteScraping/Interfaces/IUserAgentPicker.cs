using System.Threading.Tasks;

namespace LotteryCoreConsole.WebsiteScraping.Interfaces
{
    public interface IUserAgentPicker
    {
        Task<string> RandomUserAgentAsync();
    }
}