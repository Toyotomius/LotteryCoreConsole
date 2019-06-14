using System;
using System.Linq;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LotteryCoreConsole.WebsiteScraping
{
    public class WebsiteScraping
    {
        private readonly Random _rand = new Random();

        public void Scrape()
        {
            string[] uagents =
            {
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/602.1.50 (KHTML, like Gecko) Version/10.0 Safari/602.1.50",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.11; rv:49.0) Gecko/20100101 Firefox/49.0",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_1) AppleWebKit/602.2.14 (KHTML, like Gecko) Version/10.0.1 Safari/602.2.14",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12) AppleWebKit/602.1.50 (KHTML, like Gecko) Version/10.0 Safari/602.1.50",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
                "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
                "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
                "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0",
                "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
                "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
                "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0",
                "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko",
                "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0",
                "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
                "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
                "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:49.0) Gecko/20100101 Firefox/49.0"
            };

            int randomUserAgentIndex = _rand.Next(uagents.Length);

            ChromeOptions coptions = new ChromeOptions();
            coptions.AddArgument($"--user-agent={uagents[randomUserAgentIndex]}");
            coptions.AddArgument("headless");
            IWebDriver driver = new ChromeDriver(coptions);

            driver.Url = "http://localhost:8000/test.htm";

            //Screenshot sh = driver.GetScreenshot();
            //sh.SaveAsFile(@"C:\Misc\Temp.jpg", ImageFormat.Png);

            var source = driver.PageSource;
            var alc = new HtmlDocument();
            alc.LoadHtml(source);

            Console.WriteLine("BreakPoint");

            // ALC Winner Website: https://www.alc.ca/content/alc/en/winning-numbers.html

            var lotto649 = alc.DocumentNode.SelectNodes("//div[@class='panel-group category-accordion-Lotto649']");
            var lottoMaxDrawDate = alc.DocumentNode.SelectSingleNode("//script[contains(.,'gameId: \"Lotto649\"')]");
            var drawdateIndex = lottoMaxDrawDate.InnerHtml.LastIndexOf("drawDatesData");
            var test = lottoMaxDrawDate.InnerText.Substring(drawdateIndex);
            var lottoMaxDrawNums = lotto649.Descendants("li").Select(x => x.InnerText).ToArray();

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