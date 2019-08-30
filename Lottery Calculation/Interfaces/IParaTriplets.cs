using System.Collections.Generic;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface IParaTriplets
    {
        void FindTripsParallel(string lotteryName, (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> BonusNumbers) parsedLotto);
    }
}