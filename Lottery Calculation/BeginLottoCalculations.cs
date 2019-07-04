using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using LotteryCoreConsole.Lottery_Calculation.GetSetObjects;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;

using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole.Lottery_Calculation
{
    public class BeginLottoCalculations : IBeginLottoCalculations
    {
        private readonly INumberParsing _lottoNumberParser;

        private readonly IParaPairs _paraPairs;
        private readonly IParaSingles _paraSingles;
        private readonly IParaTriplets _paraTriplets;

        public BeginLottoCalculations(INumberParsing lottoNumberParser, IParaSingles paraSingles, IParaPairs paraPairs, IParaTriplets paraTriplets)
        {
            _lottoNumberParser = lottoNumberParser;

            _paraSingles = paraSingles;
            _paraPairs = paraPairs;
            _paraTriplets = paraTriplets;
        }

        public void LottoChain((List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo)
        {
            ILogging log = Factory.CreateLogger();
            ConcurrentBag<string> parallelLog = new ConcurrentBag<string>();
            List<LottoData> lotto = new List<LottoData>();
            Parallel.ForEach(lotteryInfo.LotteryJObject, (currentObject) =>

            {
                var i = lotteryInfo.LotteryJObject.IndexOf(currentObject);
                string lotteryName = $"{Path.GetFileNameWithoutExtension(lotteryInfo.LotteryFile[i])}";
                JObject lotteryData = lotteryInfo.LotteryJObject[i];
                IMakeLottoList createLottoList = Factory.CreateLottoList();

                try
                {
                    lotto = createLottoList.CreateLottoList(lotteryName, lotteryData);
                }
                catch (ArgumentNullException)
                {
                    parallelLog.Add(
                       $"{DateTime.Now} : Lottery Data List creation failed for \"{lotteryInfo.LotteryFile[i]}\". Verify the json file is correctly formed.\n" +
                       "    * See example.json for correct format. Ensure root object & file name are identical.");
                    //continue;
                }

                if (0 != lotto.Count)
                {
                    var parsedLotto = _lottoNumberParser.ParseLottoList(lotto);

                    _paraTriplets.FindTripsParallel(lotteryName, parsedLotto);
                    _paraPairs.FindPairsParallel(lotteryName, parsedLotto);
                    _paraSingles.FindSinglesParallel(lotteryName, parsedLotto);
                }
            });

            log.Log(string.Join(Environment.NewLine, parallelLog));
            Console.WriteLine(
                    $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                    " : Done");
        }
    }
}