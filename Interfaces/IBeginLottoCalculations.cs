using System.Collections.Generic;

using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Interfaces
{
    public interface IBeginLottoCalculations
    {
        void LottoChain((List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo);
    }
}