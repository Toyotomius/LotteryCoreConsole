using System.Threading.Tasks;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface ILottoSinglesFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}