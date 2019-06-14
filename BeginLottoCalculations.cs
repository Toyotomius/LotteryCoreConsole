using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using LotteryCoreConsole.Interfaces;

using Newtonsoft.Json.Linq;

namespace LotteryCoreConsole
{
    public class BeginLottoCalculations : IBeginLottoCalculations
    {
        private readonly INumberParsing _lottoNumberParser;

        //private IFindLottoPairs _startPairsChain;
        //private IFindLottoSingles _startSinglesChain;
        //private IFindLottoTriplets _startTripletsChain;

        private readonly IParaPairs _paraPairs;
        private readonly IParaSingles _paraSingles;
        private readonly IParaTriplets _paraTriplets;

        public BeginLottoCalculations(INumberParsing lottoNumberParser, IParaSingles paraSingles, IParaPairs paraPairs, IParaTriplets paraTriplets)
        {
            _lottoNumberParser = lottoNumberParser;
            //_startSinglesChain = startSinglesChain;
            //_startPairsChain = startPairsChain;
            //_startTripletsChain = startTripletsChain;

            _paraSingles = paraSingles;
            _paraPairs = paraPairs;
            _paraTriplets = paraTriplets;
        }

        public void LottoChain((List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo, List<string> lotteryFile)
        {
            ILogging log = Factory.CreateLogger();
            ConcurrentBag<string> parallelLog = new ConcurrentBag<string>();
            List<ILottoData> lotto = new List<ILottoData>();
            Parallel.ForEach(lotteryInfo.LotteryJObject, (currentObject) =>
            //for (var i = 0; i < lotteryInfo.LotteryJObject.Count; i++)
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
                       $"{DateTime.Now} : Lottery Data List creation failed for \"{lotteryFile[i]}\". Verify the json file is correctly formed.\n" +
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
                //await Task.WhenAll(
                //    _startSinglesChain.FindSinglesAsync(lotteryName, parsedLotto),
                //   _startPairsChain.FindPairsAsync(lotteryName, parsedLotto),
                //   _startTripletsChain.FindTripsAsync(lotteryName, parsedLotto)
                //);

                //_startSinglesChain.FindSinglesAsync(lotteryName, parsedLotto);
                //_startPairsChain.FindPairsAsync(lotteryName, parsedLotto);
                //await _startTripletsChain.FindTripsAsync(lotteryName, parsedLotto);
            });

            log.Log(string.Join(Environment.NewLine, parallelLog));
            Console.WriteLine(
                    $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                    $" : Breakpoint");

            Console.WriteLine("Done");
        }

        public async Task StartLottoListsAsync()
        {
            //while (true)

            ISetSettings settings = Factory.SetNewSettings();

            // Retrieves the filename and the list of Json objects from the files as a tuple.
            (List<string> LotteryFile, List<JObject> LotteryJObject) lotteryInfo = await settings.ApplySettingsAsync();
            List<string> lotteryFile = lotteryInfo.LotteryFile;

            // TODO: Check to see if a file has been added to.Ignore it if it hasn't been.
            // TODO: Clean up logfile at various points.

            // Iterates through confirmed file data and
            //for (var i = 0; i < lotteryInfo.LotteryJObject.Count; i++
            LottoChain(lotteryInfo, lotteryFile);
        }
    }
}