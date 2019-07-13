using LotteryCoreConsole.FileManagement;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

using System.IO;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public class WriteNewLottoResult : FileOut, IWriteNewLottoResult
    {
        private string _contents = "";

        /// <summary>
        /// Takes the new scraped lottery data, inserts it into the existing file at the top and writes the new file.
        /// </summary>
        /// <param name="lotteryName"></param>
        /// <param name="newResults"></param>
        /// <returns></returns>
        public async Task WriteNewResults(string lotteryName, string newResults)
        {
            // Reads current file into memory
            var path = $@".\Data Files\{lotteryName}.json";
            using (StreamReader sr = new StreamReader(path))
            {
                _contents = sr.ReadToEnd();
            }

            var index = _contents.IndexOf("[") + 1; // +1 to insert to the _right_ of the indicated character.
            var newFileTask = Task.Run(() => _contents.Insert(index, newResults));
            var newFile = await newFileTask;

            await base.WriteFile(path, newFile);
        }
    }
}