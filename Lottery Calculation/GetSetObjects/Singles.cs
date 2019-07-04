using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.Lottery_Calculation.GetSetObjects
{
    public class Singles : ISingles
    {
        public int First { get; set; }

        public int Frequency { get; set; }
    }
}