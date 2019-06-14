using System.Threading.Tasks;

namespace LotteryCoreConsole.Interfaces
{
    public interface IFileOut
    {
        Task WriteFile(string lotteryName, string data);
    }
}