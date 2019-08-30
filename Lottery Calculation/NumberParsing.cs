using System.Collections.Generic;
using System.Linq;
using LotteryCoreConsole.Lottery_Calculation.GetSetObjects;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.Lottery_Calculation
{
    public class NumberParsing : INumberParsing
    {
        public IEnumerable<int[]> AllNumbers { get; set; } // Selects all the number arrays from the list.

        public IEnumerable<int> DistinctNumbers { get; set; } // Grabs just the distinct numbers in the list.
        public IEnumerable<int> BonusNumbers { get; set; }

        public (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> Bonus) ParseLottoList(List<LottoData> lotto)
        {
            (IEnumerable<int[]>, IEnumerable<int>, IEnumerable<int>) results = (AllNumbers = lotto.Select(a => a.Numbers),
                DistinctNumbers = lotto.SelectMany(a => a.Numbers).Distinct(),
                BonusNumbers = lotto.Select(a => a.Bonus));

            return results;
        }

        //TODOCompleted Optimization. Review later.
    }
}

// TODO: Calculate bonus frequency separately.