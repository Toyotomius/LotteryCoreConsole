using System.Threading.Tasks;

namespace LotteryCoreConsole.Interfaces
{
    public interface ILottoSinglesFileOut
    {
        Task WriteFileAsync(string lotteryName, string data);
    }
}