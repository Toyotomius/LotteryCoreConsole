using System;
using System.IO;
using System.Threading.Tasks;
using LotteryCoreConsole.FileManagement;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public class LottoEventArgs : EventArgs
    {
        public string LotteryName { get; set; }
        public string LotteryData { get; set; }
    }

    public class WriteNewLottoResult : FileOut, IWriteNewLottoResult
    {
        private string _contents = "";

        public event EventHandler<LottoEventArgs> NewLotteryResultsWritten;

        /// <summary>
        ///     Takes the new scraped lottery data, inserts it into the existing file at the top and writes the new file.
        /// </summary>
        /// <param name="lotteryName"></param>
        /// <param name="newResults"></param>
        /// <returns></returns>
        public async Task WriteNewResults(string lotteryName, string newResults)
        {
            // Reads current file into memory
            string path = $@".\Data Files\{lotteryName}.json";
            using (var sr = new StreamReader(path))
            {
                _contents = sr.ReadToEnd();
            }

            int index = _contents.IndexOf("[") + 1; // +1 to insert to the _right_ of the indicated character.
            Task<string> newFileTask = Task.Run(() => _contents.Insert(index, newResults));
            string newFile = await newFileTask;

            await WriteFile(path, newFile);

            // Raises event after the writing is finished to update the singles, pairs & triplets data.
            OnNewResultsWritten(lotteryName, newFile);
        }

        /// <summary>
        ///     Event to update the frequency result data.
        /// </summary>
        protected void OnNewResultsWritten(string lotteryName, string newFile)
        {
            NewLotteryResultsWritten?.Invoke(this, new LottoEventArgs {LotteryName = lotteryName, LotteryData = newFile});
        }
    }
}