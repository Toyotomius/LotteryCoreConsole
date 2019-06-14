using System.Collections.Generic;

namespace LotteryCoreConsole.Interfaces
{
    public interface IListJsonSerializer
    {
        string JSerialize<T>(List<T> lottoList);
    }
}