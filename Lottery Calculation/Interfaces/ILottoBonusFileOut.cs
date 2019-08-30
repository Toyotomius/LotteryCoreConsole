using System.Threading.Tasks;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface ILottoBonusFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}