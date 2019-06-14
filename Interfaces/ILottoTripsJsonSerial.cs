using System.Collections.Generic;
using System.Threading.Tasks;

using LotteryCoreConsole.GetSetObjects;

namespace LotteryCoreConsole.Interfaces
{
    public interface ILottoTripsJsonSerial
    {
        Task TripsSerializeAsync(string lotteryName, List<Triplets> tripletList);
    }
}