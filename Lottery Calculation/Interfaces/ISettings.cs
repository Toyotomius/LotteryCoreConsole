using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface ISettings
    {
        Task<JObject> ReadSettings();
    }
}