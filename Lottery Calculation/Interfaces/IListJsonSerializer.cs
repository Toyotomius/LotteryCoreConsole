using System.Collections.Generic;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface IListJsonSerializer
    {
        string JSerialize<T>(IList<T> lottoList);
    }
}