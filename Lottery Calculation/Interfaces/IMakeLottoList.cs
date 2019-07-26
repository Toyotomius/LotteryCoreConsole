using System.Collections.Generic;
using LotteryCoreConsole.Lottery_Calculation.GetSetObjects;
using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface IMakeLottoList
    {
        List<LottoData> CreateLottoList(string lotteryName, JObject lotteryData);
    }
}