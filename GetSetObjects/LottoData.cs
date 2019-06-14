using LotteryCoreConsole.Interfaces;

namespace LotteryCoreConsole.GetSetObjects
{
    public class LottoData : ILottoData
    {
        public string Date { get; set; }

        public int[] Numbers { get; set; }
    }
}