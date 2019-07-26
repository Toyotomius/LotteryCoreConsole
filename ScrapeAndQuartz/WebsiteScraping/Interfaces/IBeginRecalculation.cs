namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces
{
    public interface IBeginRecalculation
    {
        void PrepareNewCalcDataAsync(string lotteryName, string lotteryJsonString);
    }
}