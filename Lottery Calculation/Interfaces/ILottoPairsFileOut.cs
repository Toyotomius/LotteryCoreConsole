using System.Threading.Tasks;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface ILottoPairsFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}