using System;
using System.Threading.Tasks;

using LotteryCoreConsole.Interfaces;

namespace LotteryCoreConsole.SinglesCode
{
    public class LottoSinglesFileOut : ILottoSinglesFileOut
    {
        private readonly IFileOut _fileOut;

        public LottoSinglesFileOut(IFileOut fileOut)
        {
            _fileOut = fileOut;
        }

        public async Task WriteFileAsync(string lotteryName, string data)
        {
            string path = $"{lotteryName}Singles.json";
            await _fileOut.WriteFile(path, data);
            Console.WriteLine(
                $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Singles Finished");
        }
    }
}