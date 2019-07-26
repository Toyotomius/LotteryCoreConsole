using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.Lottery_Calculation.GetSetObjects
{
    public class Pairs : Singles, IPairs
    {
        public int Second { get; set; }
    }
}