using System.Collections.Generic;

using LotteryCoreConsole.Interfaces;

using Newtonsoft.Json;

namespace LotteryCoreConsole
{
    public class ListJsonSerializer : IListJsonSerializer
    {
        public string JSerialize<T>(List<T> lottoList)
        {
            string frequencyJson = JsonConvert.SerializeObject(lottoList, Formatting.Indented);
            return frequencyJson;
        }
    }
}