using System.Collections.Generic;

using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Interfaces
{
    public interface IMakeLottoList
    {
        List<ILottoData> CreateLottoList(string lotteryName, JObject lotteryData);
    }
}