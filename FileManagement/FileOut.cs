using System.IO;
using System.Threading.Tasks;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.FileManagement
{
    public class FileOut : IFileOut
    {
        public async Task WriteFile(string path, string data)
        {
            using (var sw = new StreamWriter(path))
            {
                // ReSharper disable once AccessToDisposedClosure - Resolved issue with program exit before write was finished.
                Task writeTask = Task.Run(() => sw.WriteLine(data));

                await writeTask;
            }
        }
    }
}