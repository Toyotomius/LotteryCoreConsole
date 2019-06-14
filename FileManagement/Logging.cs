using System.IO;
using LotteryCoreConsole.Interfaces;

namespace LotteryCoreConsole.FileManagement
{
    public class Logging : ILogging
    {
        private readonly string _logFile = "Logfile.txt";

        public void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter(_logFile, append: true))
            {
                sw.WriteLine(message);
            }
        }
    }
}