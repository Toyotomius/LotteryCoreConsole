using System.Collections.Generic;

namespace LotteryCoreConsole.Interfaces
{
    public interface IParaSingles
    {
        void FindSinglesParallel(string lotteryName, (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto);
    }
}