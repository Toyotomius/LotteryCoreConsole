using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LotteryCoreConsole.Lottery_Calculation.GetSetObjects;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.Lottery_Calculation
{
    public class BeginLottoCalculations : IBeginLottoCalculations
    {
        private readonly INumberParsing _lottoNumberParser;
        private readonly IParaBonus _paraBonus;
        private readonly IParaPairs _paraPairs;
        private readonly IParaSingles _paraSingles;
        private readonly IParaTriplets _paraTriplets;

        public BeginLottoCalculations(INumberParsing lottoNumberParser, IParaSingles paraSingles, IParaPairs paraPairs,
            IParaTriplets paraTriplets, IParaBonus paraBonus)
        {
            _lottoNumberParser = lottoNumberParser;
            _paraBonus = paraBonus;
            _paraSingles = paraSingles;
            _paraPairs = paraPairs;
            _paraTriplets = paraTriplets;
        }

        public async Task LottoChain(string lotteryName, List<LottoData> lotto)
        {
            if (0 != lotto.Count)
            {
                string resultsPath = $"./Lottery Results/{lotteryName}/";
                if (!Directory.Exists(resultsPath)) Directory.CreateDirectory(resultsPath);
                (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> BonusNumbers) parsedLotto =
                    _lottoNumberParser.ParseLottoList(lotto);

                _paraTriplets.FindTripsParallel(lotteryName, parsedLotto);
                _paraPairs.FindPairsParallel(lotteryName, parsedLotto);
                _paraSingles.FindSinglesParallel(lotteryName, parsedLotto);
                _paraBonus.FindBonusParallel(lotteryName, parsedLotto);
            }

            Console.WriteLine(
                $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                " : Done");
        }
    }
}