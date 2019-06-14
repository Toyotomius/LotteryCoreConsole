using System.Collections.Generic;
using System.Threading.Tasks;

using LotteryCoreConsole.GetSetObjects;

namespace LotteryCoreConsole.Interfaces
{
    public interface ILottoPairsJsonSerial
    {
        Task PairsSerializeAsync(string lotteryName, List<Pairs> pairsList);
    }
}