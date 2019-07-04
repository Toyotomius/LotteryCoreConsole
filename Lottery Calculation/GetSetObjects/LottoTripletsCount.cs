using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.Lottery_Calculation.GetSetObjects
{
    public class Triplets : Pairs, ITriplets
    {
        public int Third { get; set; }
    }
}