using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using HtmlAgilityPack;

using LotteryCoreConsole.WebsiteScraping.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LotteryCoreConsole.WebsiteScraping
{
    public interface IWebsiteScraping
    {
        Task ScrapeAsync();
    }

    public class WebsiteScraping : IWebsiteScraping
    {
        private IUserAgentPicker _uAgentPicker;

        public WebsiteScraping(IUserAgentPicker uAgentPicker)
        {
            _uAgentPicker = uAgentPicker;
        }

        public async Task ScrapeAsync()
        {
            string uAgent = await _uAgentPicker.RandomUserAgentAsync();
            ChromeOptions coptions = new ChromeOptions();
            coptions.AddArgument($"--user-agent={uAgent}");
            coptions.AddArgument("headless");
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), coptions);

            driver.Url = "http://localhost:8000/test.htm";

            //Screenshot sh = driver.GetScreenshot();
            //sh.SaveAsFile(@"C:\Misc\Temp.jpg", ImageFormat.Png);

            var source = driver.PageSource;
            var alc = new HtmlDocument();
            alc.LoadHtml(source);

            Console.WriteLine("BreakPoint");

            // ALC Winner Website: https://www.alc.ca/content/alc/en/winning-numbers.html

            var lotto649 = alc.DocumentNode.SelectNodes("//div[@class='panel-group category-accordion-Lotto649']");
            var lotto649DrawDate = alc.DocumentNode.SelectSingleNode("//script[contains(.,'gameId: \"Lotto649\"')]");
            var drawdateIndex = lotto649DrawDate.InnerHtml.LastIndexOf("drawDatesData");
            var test = lotto649DrawDate.InnerText.Substring(drawdateIndex);
            var lotto649DrawNums = lotto649.Descendants("li").Select(x => x.InnerText).ToArray();

            Console.WriteLine("BreakPoint");
            //var lottoMax = alc.DocumentNode.SelectNodes("//div[@id='lotto-LottoMax']");
            //var lottoMaxDrawDate = lottoMax.Descendants("input").First().Attributes["value"].Value;
            //var lottoMaxDrawNums = lottoMax.Descendants("li").Select(x => x.InnerText).ToArray();

            //foreach (var itm in lotto649)
            //{
            //    Console.WriteLine(itm.ToString());
            //    Console.WriteLine("Breakpoint");
            //}
            return;
        }

        // TODO: Set date by automated scrape time. Or use a regex to parse the <script> for the latest date.
        // TODO: Set up some scraping. Tie it into the config file for any number of websites desired. Put the results
        // scrapped into a correct format and insert it into the appropriate json file.

        //TODO: Put the websites to be scraped in the settings file.
    }
}