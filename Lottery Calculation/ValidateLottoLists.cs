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
    public class ValidateLottoLists : IValidateLottoLists
    {
        private readonly IBeginLottoCalculations _beginCalculations;

        public ValidateLottoLists(IBeginLottoCalculations beginCalculations)
        {
            _beginCalculations = beginCalculations;
        }

        public async Task ValidateLotteryLists((List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo)
        {
            ILogging log = Factory.CreateLogger();
            ConcurrentBag<string> parallelLog = new ConcurrentBag<string>();
            List<LottoData> lotto = new List<LottoData>();
            Task<ParallelLoopResult> task = Task.Run(() => Parallel.ForEach(lotteryInfo.LotteryJObject, currentObject =>
            {
                int i = lotteryInfo.LotteryJObject.IndexOf(currentObject);
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
                }

                _beginCalculations.LottoChain(lotteryName, lotto);
            }));
            log.Log(string.Join(Environment.NewLine, parallelLog));
            await task;
        }
    }
}