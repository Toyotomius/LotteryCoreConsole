using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using OpenQA.Selenium.Chrome;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public interface IWebsiteScraping
    {
        Task<string> RetrievePageSource(string lotterySite);
    }

    public class WebsiteScraping : IWebsiteScraping
    {
        private readonly IUserAgentPicker _uAgentPicker;

        public WebsiteScraping(IUserAgentPicker uAgentPicker)
        {
            _uAgentPicker = uAgentPicker;
        }

        public virtual async Task<string> RetrievePageSource(string lotterySite)
        {
            string uAgent = await _uAgentPicker.RandomUserAgentAsync();
            var coptions = new ChromeOptions();
            coptions.AddArgument($"--user-agent={uAgent}");
            coptions.AddArgument("headless");
            var driver =
                new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), coptions)
                {
                    Url = lotterySite
                };
            Task<string> source = Task.Run(() => driver.PageSource);

            //Screenshot sh = driver.GetScreenshot();
            //sh.SaveAsFile(@"C:\Misc\Temp.jpg", ImageFormat.Png);

            // ALC Winner Website: https://www.alc.ca/content/alc/en/winning-numbers.html

            //var lottoMax = alc.DocumentNode.SelectNodes("//div[@id='lotto-LottoMax']");
            //var lottoMaxDrawDate = lottoMax.Descendants("input").First().Attributes["value"].Value;
            //var lottoMaxDrawNums = lottoMax.Descendants("li").Select(x => x.InnerText).ToArray();

            //foreach (var itm in lotto649)
            //{
            //    Console.WriteLine(itm.ToString());
            //    Console.WriteLine("Breakpoint");
            //}
            return await source;
        }

        // TODO: Set date by automated scrape time. Or use a regex to parse the <script> for the latest date.

        // TODO: Remember sanity checks.

        //TODO: Put the websites to be scraped in the settings file.
    }
}
