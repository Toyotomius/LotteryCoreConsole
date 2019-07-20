using System;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public class AfterLottoWritten
    {
        public void OnResultsWritten(object source, LottoEventArgs e)
        {
            Console.WriteLine($"Testing Events {e.Name}");
        }
    }
}