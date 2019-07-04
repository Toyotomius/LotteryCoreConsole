using System.Threading.Tasks;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface IFileOut
    {
        Task WriteFile(string lotteryName, string data);
    }
}