﻿using System.Collections.Generic;
using System.Linq;

using LotteryCoreConsole.GetSetObjects;
using LotteryCoreConsole.Interfaces;

using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole
{
    public class MakeLottoList : IMakeLottoList
    {
        private readonly List<LottoData> _lottoData = new List<LottoData>();

        public List<LottoData> CreateLottoList(string lotteryName, JObject lotteryData)
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