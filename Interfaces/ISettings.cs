using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Interfaces
{
    public interface ISettings
    {
        Task<JObject> ReadSettings();
    }
}