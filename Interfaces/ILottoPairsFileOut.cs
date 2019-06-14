using System.Threading.Tasks;

namespace LotteryCoreConsole.Interfaces
{
    public interface ILottoPairsFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}