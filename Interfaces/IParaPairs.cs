using System.Collections.Generic;

namespace LotteryCoreConsole.Interfaces
{
    public interface IParaPairs
    {
        void FindPairsParallel(string lotteryName, (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto);
    }
}