using System.Collections.Generic;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;
using Newtonsoft.Json;

namespace LotteryCoreConsole.FileManagement
{
    public class ListJsonSerializer : IListJsonSerializer
    {
        public string JSerialize<T>(IList<T> lottoList)
        {
            string frequencyJson = JsonConvert.SerializeObject(lottoList, Formatting.Indented);
            return frequencyJson;
        }
    }
}