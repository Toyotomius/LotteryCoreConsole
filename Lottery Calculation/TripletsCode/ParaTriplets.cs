using LotteryCoreConsole.Lottery_Calculation.GetSetObjects;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LotteryCoreConsole.Lottery_Calculation.TripletsCode
{
    public class ParaTriplets : IParaTriplets
    {
        private readonly ILottoTripsJsonSerial _tripsJsonSerial;

        public ParaTriplets(ILottoTripsJsonSerial tripsJsonSerial)
        {
            _tripsJsonSerial = tripsJsonSerial;
        }

        public void FindTripsParallel(string lotteryName,
                                      (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> BonusNumbers) parsedLotto)
        {
            Console.WriteLine(
                $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Triplets Started");
            var trips =
                (from firstNum in parsedLotto.DistinctNumbers
                 from secondNum in parsedLotto.DistinctNumbers
                 from thirdNum in parsedLotto.DistinctNumbers
                 where firstNum.CompareTo(secondNum) < 0 && firstNum.CompareTo(thirdNum) < 0 && secondNum.CompareTo(thirdNum) < 0
                 select new Triplets { First = firstNum, Second = secondNum, Third = thirdNum }).Cast<ITriplets>().ToList();

            IList<ITriplets> tripletList =
                (from l in parsedLotto.AllNumbers
                 from p in trips
                 where l.Contains(p.First) && l.Contains(p.Second) && l.Contains(p.Third)
                 group l by p
                    into g
                 orderby g.Count() descending
                 select new Triplets
                 {
                     First = g.Key.First,
                     Second = g.Key.Second,
                     Third = g.Key.Third,
                     Frequency = g.Count()
                 }).Cast<ITriplets>().ToList();

            _tripsJsonSerial.TripsSerializeAsync(lotteryName, tripletList);
        }
    }
}