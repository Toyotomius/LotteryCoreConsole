using System.Collections.Generic;
using System.Threading.Tasks;

using LotteryCoreConsole.GetSetObjects;

namespace LotteryCoreConsole.Interfaces
{
    public interface ILottoSinglesJsonSerial
    {
        Task SinglesSerializeAsync(string lotteryName, List<Singles> singlesList);
    }
}