using System.Collections.Generic;
using System.Linq;

using LotteryCoreConsole.Interfaces;

namespace LotteryCoreConsole
{
    public class NumberParsing : INumberParsing
    {
        public IEnumerable<int[]> AllNumbers { get; set; } // Selects all the number arrays from the list.

        public IEnumerable<int> DistinctNumbers { get; set; } // Grabs just the distinct numbers in the list.

        public (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) ParseLottoList(List<ILottoData> lotto)
        {
            (IEnumerable<int[]>, IEnumerable<int>) results = (AllNumbers = lotto.Select(a => a.Numbers),
                DistinctNumbers = lotto.SelectMany(a => a.Numbers).Distinct());

            return results;
        }

        //TODOCompleted Optimization. Review later.
    }
}

// TODO: Calculate bonus frequency separately.