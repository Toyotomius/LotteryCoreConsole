using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface ILottoPairsJsonSerial
    {
        Task PairsSerializeAsync(string lotteryName, IList<IPairs> pairsList);
    }
}