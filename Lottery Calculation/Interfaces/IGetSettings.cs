using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface IGetSettings
    {
        Task<(List<string> lotteryFile, List<JObject> lotteryJObject, bool scrapeWebsites)> RetrieveSettings();
    }
}