using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotteryCoreConsole.Interfaces
{
    public interface ILottoTripsJsonSerial
    {
        Task TripsSerializeAsync(string lotteryName, IList<ITriplets> tripletList);
    }
}