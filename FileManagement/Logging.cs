using System.IO;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.FileManagement
{
    public class Logging : ILogging
    {
        private readonly string _logFile = "Logfile.txt";

        public void Log(string message)
        {
            using (var sw = new StreamWriter(_logFile, true))
            {
                sw.WriteLine(message);
            }
        }
    }
}