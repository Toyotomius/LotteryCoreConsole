using System.Threading.Tasks;

namespace LotteryCoreConsole.Interfaces
{
    public interface ILottoTripsFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}