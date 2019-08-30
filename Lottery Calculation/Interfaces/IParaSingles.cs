using System.Collections.Generic;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface IParaSingles
    {
        void FindSinglesParallel(string lotteryName,
                                 (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> BonusNumbers) parsedLotto);
    }
}