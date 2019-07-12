using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface IBeginLottoCalculations
    {
        Task LottoChain((List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo);
    }
}