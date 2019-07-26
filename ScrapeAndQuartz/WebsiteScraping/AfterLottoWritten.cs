using System;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public class AfterLottoWritten : IAfterLottoWritten
    {
        private readonly IBeginRecalculation _beginRecalc;

        public AfterLottoWritten(IBeginRecalculation beginRecalc)
        {
            _beginRecalc = beginRecalc;
        }

        /// <summary>
        ///     Event handler that uses custom args to pass the lottery name and Json string to method that creates the tuple
        ///     needed for the validator that handles the calculations.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnResultsWritten(object source, LottoEventArgs e)
        {
            _beginRecalc.PrepareNewCalcDataAsync(e.LotteryName, e.LotteryData);
            Console.WriteLine("On Results Written");
        }
    }
}