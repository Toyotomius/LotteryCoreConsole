using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotteryCoreConsole.Interfaces
{
    public interface ILottoSinglesJsonSerial
    {
        Task SinglesSerializeAsync(string lotteryName, IList<ISingles> singlesList);
    }
}