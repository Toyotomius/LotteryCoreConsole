using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    /// <summary>
    ///     Scrapes the Atlantic Lottery Corporation Website @ https://www.alc.ca/content/alc/en/winning-numbers.html for the
    ///     winning Lotto649 numbers. Draws every Wed and Sat.
    /// </summary>
    public class Lotto649Scrape : WebsiteScraping, ILotto649Scrape
    {
        private readonly IFormatNewLotteryResult _formatNewLotteryResult;
        private readonly IWriteNewLottoResult _writeNewResult;

        /// <summary>
        ///     Constructor uses uAgentPicker (not really) from base class, FormatNewLottery and WriteNewLottoResults to
        ///     handle the information returned from the scrape.
        /// </summary>
        /// <param name="uAgentPicker"></param>
        /// <param name="formatNewLotteryResult"></param>
        /// <param name="writeNewLottoResult"></param>
        public Lotto649Scrape(IUserAgentPicker uAgentPicker, IFormatNewLotteryResult formatNewLotteryResult,
            IWriteNewLottoResult writeNewLottoResult) : base(uAgentPicker)
        {
            _formatNewLotteryResult = formatNewLotteryResult;
            _writeNewResult = writeNewLottoResult;
        }

        /// <summary>
        ///     Scrapes the winning results for Lotto649 with help from base class.
        /// </summary>
        /// <returns></returns>
        public async Task ScrapeLotto649Async()
        {
            var driver = await base.CreateDriverAsync().ConfigureAwait(false);
            driver.Url = "http://localhost:8000/test.htm";

            var source = driver.PageSource;
            var alc = new HtmlDocument();
            alc.LoadHtml(source);

            var lotto649 = alc.DocumentNode.SelectNodes("//div[@class='panel-group category-accordion-Lotto649']");
            var lotto649DrawDate = alc.DocumentNode.SelectSingleNode("//script[contains(.,'gameId: \"Lotto649\"')]");
            var drawdateIndex = lotto649DrawDate.InnerHtml.LastIndexOf("drawDatesData");

            var lotto649DrawNumsArray = lotto649.Descendants("li").Select(x => x.InnerText).ToArray();
            var lotto649DrawNums = string.Join(", ", lotto649DrawNumsArray);

            var newResults = await _formatNewLotteryResult.FormatResult(lotto649DrawNums);
            var afterLotto = new AfterLottoWritten();
            _writeNewResult.NewLotteryResultsWritten += afterLotto.OnResultsWritten;
            var writeTask = Task.Run(() => _writeNewResult.WriteNewResults("Lotto649", newResults));
            await writeTask;
        }
    }
}

// TODO: Sanity checks.