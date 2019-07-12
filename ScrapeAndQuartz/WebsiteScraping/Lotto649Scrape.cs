using HtmlAgilityPack;

using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public class Lotto649Scrape : WebsiteScraping, ILotto649Scrape
    {
        public Lotto649Scrape(IUserAgentPicker uAgentPicker) : base(uAgentPicker)
        {
        }

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

            var lotto649DrawNums = lotto649.Descendants("li").Select(x => x.InnerText).ToArray();

            Console.WriteLine("Breakpoint");
        }
    }
}