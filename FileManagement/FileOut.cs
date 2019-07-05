using System.IO;
using System.Threading.Tasks;

using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.FileManagement
{
    public class FileOut : IFileOut
    {
        public async Task WriteFile(string path, string data)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                Task writeTask = Task.Run(() => sw.WriteLine(data));

                await writeTask;
            }
        }
    }
}