using System.Threading.Tasks;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface ILottoTripsFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}