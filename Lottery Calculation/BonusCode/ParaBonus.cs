using LotteryCoreConsole.Lottery_Calculation.GetSetObjects;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LotteryCoreConsole.Lottery_Calculation.SinglesCode
{
    public class ParaBonus : IParaBonus
    {
        private readonly ILottoBonusJsonSerial _bonusJsonSerial;

        public ParaBonus(ILottoBonusJsonSerial bonusJsonSerial)
        {
            _bonusJsonSerial = bonusJsonSerial;
        }

        public void FindBonusParallel(string lotteryName,
                                      (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> BonusNumbers) parsedLotto)
        {
            Console.WriteLine(
                $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Singles Started");
            var singlesList = (from n in parsedLotto.BonusNumbers.Select(x => x)
                               group n by n
                               into g
                               orderby g.Count() descending
                               select new Singles { First = g.Key, Frequency = g.Count() }).Cast<ISingles>().ToList();

            _bonusJsonSerial.BonusSerializeAsync(lotteryName, singlesList);
        }
    }
}
