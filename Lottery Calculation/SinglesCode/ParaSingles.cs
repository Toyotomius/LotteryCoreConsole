using System;
using System.Collections.Generic;
using System.Linq;
using LotteryCoreConsole.Lottery_Calculation.GetSetObjects;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.Lottery_Calculation.SinglesCode
{
    public class ParaSingles : IParaSingles
    {
        private readonly ILottoSinglesJsonSerial _singlesJsonSerial;

        public ParaSingles(ILottoSinglesJsonSerial singlesJsonSerial)
        {
            _singlesJsonSerial = singlesJsonSerial;
        }

        public void FindSinglesParallel(string lotteryName,
                                        (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> BonusNumbers) parsedLotto)
        {
            Console.WriteLine(
                $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Singles Started");
            List<ISingles> singlesList = (from n in parsedLotto.AllNumbers.SelectMany(x => x)
                group n by n
                into g
                orderby g.Count() descending
                select new Singles {First = g.Key, Frequency = g.Count()}).Cast<ISingles>().ToList();

            _singlesJsonSerial.SinglesSerializeAsync(lotteryName, singlesList);
        }
    }
}