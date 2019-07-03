using System.Collections.Generic;

using LotteryCoreConsole.GetSetObjects;

using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Interfaces
{
    public interface IMakeLottoList
    {
        List<LottoData> CreateLottoList(string lotteryName, JObject lotteryData);
    }
}