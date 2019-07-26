using System.Collections.Generic;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;
using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping
{
    public class BeginRecalculation : IBeginRecalculation
    {
        private readonly IValidateLottoLists _validateLottoList;

        /// <summary>
        ///     Uses validateLottoList to start the new frequency calculation for the just-scrapped lottery.
        /// </summary>
        /// <param name="validateLottoList"></param>
        public BeginRecalculation(IValidateLottoLists validateLottoList)
        {
            _validateLottoList = validateLottoList;
        }

        /// <summary>
        ///     Creates the tuple that the validator is looking for.
        /// </summary>
        /// <param name="lotteryName"></param>
        /// <param name="lotteryJsonString">String in Json format from the lottery website scrape</param>
        public void PrepareNewCalcDataAsync(string lotteryName, string lotteryJsonString)
        {
            List<string> lotteryFile = new List<string> {lotteryName};

            JObject lotteryJObject = JObject.Parse(lotteryJsonString);
            List<JObject> jObjectList = new List<JObject> {lotteryJObject};
            (List<string> lotteryFile, List<JObject> lotteryJObject) lotteryInfo = (lotteryFile, jObjectList);

            _validateLottoList.ValidateLotteryLists(lotteryInfo);
        }
    }
}