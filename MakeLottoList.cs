using System.Collections.Generic;
using System.Linq;

using LotteryCoreConsole.GetSetObjects;
using LotteryCoreConsole.Interfaces;

using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole
{
    public class MakeLottoList : IMakeLottoList
    {
        private readonly List<ILottoData> _lottoData = new List<ILottoData>();

        public List<ILottoData> CreateLottoList(string lotteryName, JObject lotteryData)
        {
            //TODO: Find a better way of doing this.
            // Iterates through the lottery JObject and returns an ordered list of <string Date, int[] Numbers> to be manipulated.
            for (int i = 0; i < lotteryData[lotteryName].Count(); i++)
            {
                _lottoData.Add(new LottoData
                {
                    Date = lotteryData[lotteryName][i]["Date"].ToString(),
                    Numbers = lotteryData[lotteryName][i]["Numbers"].Select(x => (int)x).ToArray()
                });
            }

            return _lottoData;
        }
    }
}