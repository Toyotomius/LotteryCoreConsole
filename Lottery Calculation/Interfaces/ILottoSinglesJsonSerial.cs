using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface ILottoSinglesJsonSerial
    {
        Task SinglesSerializeAsync(string lotteryName, IList<ISingles> singlesList);
    }
}