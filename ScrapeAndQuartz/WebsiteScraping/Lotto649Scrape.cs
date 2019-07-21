using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using OpenQA.Selenium;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    /// <summary>
    ///     Scrapes the Atlantic Lottery Corporation Website @ https://www.alc.ca/content/alc/en/winning-numbers.html for the
    ///     winning Lotto649 numbers. Draws every Wed and Sat.
    /// </summary>
    public class Lotto649Scrape : ILotteryScrape
    {
        private readonly IFormatNewLotteryResult _formatNewLotteryResult;
        private readonly IWriteNewLottoResult _writeNewResult;
        private readonly IWebsiteScraping _websiteScraping;

        /// <summary>
        ///     Constructor uses uAgentPicker (not really) from base class, FormatNewLottery and WriteNewLottoResults to
        ///     handle the information returned from the scrape.
        /// </summary>
        /// <param name="websiteScraping"></param>
        /// <param name="formatNewLotteryResult"></param>
        /// <param name="writeNewLottoResult"></param>
        public Lotto649Scrape(IWebsiteScraping websiteScraping, IFormatNewLotteryResult formatNewLotteryResult,
            IWriteNewLottoResult writeNewLottoResult)
        {
            _websiteScraping = websiteScraping;
            _formatNewLotteryResult = formatNewLotteryResult;
            _writeNewResult = writeNewLottoResult;
        }

        /// <summary>
        ///     Scrapes the winning results for Lotto649 with help from base class.
        /// </summary>
        /// <returns></returns>
        public async Task ScrapeLotteryAsync()
        {
            var lotteryUrl = "http://localhost:8000/test.htm";
            string source = await _websiteScraping.RetrievePageSource(lotteryUrl).ConfigureAwait(false);
            var lotteryWebpage = new HtmlDocument();
            lotteryWebpage.LoadHtml(source);


            HtmlNodeCollection lotto649 =
                lotteryWebpage.DocumentNode.SelectNodes("//div[@class='panel-group category-accordion-Lotto649']");
            HtmlNode lotto649DrawDate =
                lotteryWebpage.DocumentNode.SelectSingleNode("//script[contains(.,'gameId: \"Lotto649\"')]");
            int drawdateIndex = lotto649DrawDate.InnerHtml.LastIndexOf("drawDatesData");

            string[] lotto649DrawNumsArray = lotto649.Descendants("li").Select(x => x.InnerText).ToArray();
            string lotto649DrawNums = string.Join(", ", lotto649DrawNumsArray);

            string newResults = await _formatNewLotteryResult.FormatResult(lotto649DrawNums);
            var afterLotto = new AfterLottoWritten();
            _writeNewResult.NewLotteryResultsWritten += afterLotto.OnResultsWritten;
            Task writeTask = Task.Run(() => _writeNewResult.WriteNewResults("Lotto649", newResults));
            await writeTask;
        }
    }
}

// TODO: Sanity checks.