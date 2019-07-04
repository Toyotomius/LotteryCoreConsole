using System.Collections.Generic;
using LotteryCoreConsole.Lottery_Calculation.GetSetObjects;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface INumberParsing
    {
        IEnumerable<int[]> AllNumbers { get; set; } // Selects all the number arrays from the list.

        IEnumerable<int> DistinctNumbers { get; set; } // Grabs just the distinct numbers in the list.

        (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) ParseLottoList(List<LottoData> lotto);
    }
}