﻿using HtmlAgilityPack;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    /// <summary>
    ///     Scrapes the Atlantic Lottery Corporation Website @ https://www.alc.ca/content/alc/en/winning-numbers.html for the
    ///     winning Lotto649 numbers. Draws every Wed and Sat.
    /// </summary>
    public class LottoMaxScrape : ILotteryScrape
    {
        private readonly IAfterLottoWritten _afterLottoWritten;
        private readonly IFormatNewLotteryResult _formatNewLotteryResult;
        private readonly IWebsiteScraping _websiteScraping;
        private readonly IWriteNewLottoResult _writeNewResult;

        /// <summary>
        ///     FormatNewLottery and WriteNewLottoResults to
        ///     handle the information returned from the scrape.
        /// </summary>
        /// <param name="websiteScraping"></param>
        /// <param name="formatNewLotteryResult"></param>
        /// <param name="writeNewLottoResult"></param>
        public LottoMaxScrape(IWebsiteScraping websiteScraping, IFormatNewLotteryResult formatNewLotteryResult,
            IWriteNewLottoResult writeNewLottoResult, IAfterLottoWritten afterLottoWritten)
        {
            _websiteScraping = websiteScraping;
            _formatNewLotteryResult = formatNewLotteryResult;
            _writeNewResult = writeNewLottoResult;
            _afterLottoWritten = afterLottoWritten;
        }

        /// <summary>
        ///     Scrapes the winning results for Lotto649 with help from base class.
        /// </summary>
        /// <returns></returns>
        public async Task ScrapeLotteryAsync()
        {
            var lotteryUrl = "http://localhost:8000/test.htm";
            var source = await _websiteScraping.RetrievePageSource(lotteryUrl).ConfigureAwait(false);
            var lotteryWebpage = new HtmlDocument();
            lotteryWebpage.LoadHtml(source);

            HtmlNodeCollection lotto649 =
                lotteryWebpage.DocumentNode.SelectNodes("//div[@class='panel-group category-accordion-LottoMax']");

            var newLottoNumList = new List<string>();

            // Create a temporary list to store the lottery numbers.
            var tempList = lotto649.Descendants("li").Select(x => x.InnerText).ToList();

            // Temporary list is then used to remove any leading 0s the website may have used. Json doesn't like leading 0s on numbers (fuck 'im).
            foreach (var itm in tempList)
            {
                var newItm = itm.Replace(itm, itm.TrimStart(new[] { '0' }));
                newLottoNumList.Add(newItm);
            }

            var lotto649DrawNums = string.Join(", ", newLottoNumList);

            var newResults = await _formatNewLotteryResult.FormatResult(lotto649DrawNums);

            _writeNewResult.NewLotteryResultsWritten += _afterLottoWritten.OnResultsWritten;
            var writeTask = Task.Run(() => _writeNewResult.WriteNewResults("Lotto649", newResults));
            await writeTask;
        }
    }
}

// TODO: Sanity checks.
