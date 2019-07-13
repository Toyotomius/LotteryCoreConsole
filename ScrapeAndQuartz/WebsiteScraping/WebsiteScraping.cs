using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public interface IWebsiteScraping
    {
        Task<IWebDriver> CreateDriverAsync();
    }

    public class WebsiteScraping : IWebsiteScraping
    {
        internal readonly IUserAgentPicker UAgentPicker;

        public WebsiteScraping(IUserAgentPicker uAgentPicker)
        {
            UAgentPicker = uAgentPicker;
        }

        public virtual async Task<IWebDriver> CreateDriverAsync()
        {
            string uAgent = await UAgentPicker.RandomUserAgentAsync();
            ChromeOptions coptions = new ChromeOptions();
            coptions.AddArgument($"--user-agent={uAgent}");
            coptions.AddArgument("headless");
            Task<ChromeDriver> driverTask = Task.Run(() => new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), coptions));

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
            return await driverTask;
        }

        // TODO: Set date by automated scrape time. Or use a regex to parse the <script> for the latest date.
        // TODO: Set up some scraping. Tie it into the config file for any number of websites desired. Put the results
        // scrapped into a correct format and insert it into the appropriate json file.

        //TODO: Put the websites to be scraped in the settings file.
    }
}