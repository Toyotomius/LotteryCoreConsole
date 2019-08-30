using System;
using System.Collections.Generic;
using System.Linq;
using LotteryCoreConsole.Lottery_Calculation.GetSetObjects;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.Lottery_Calculation.PairsCode
{
    public class ParaPairs : IParaPairs
    {
        private readonly ILottoPairsJsonSerial _pairsJsonSerial;

        public ParaPairs(ILottoPairsJsonSerial pairsJsonSerial)
        {
            _pairsJsonSerial = pairsJsonSerial;
        }

        public void FindPairsParallel(string lotteryName, (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers, IEnumerable<int> BonusNumbers) parsedLotto)
        {
            Console.WriteLine(
                $"{DateTimeOffset.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")).ToString("MM/dd/yyyy hh:mm:ss.fff tt")}" +
                $" : {lotteryName} Pairs Started");
            List<IPairs> pairs = (
                from firstNum in parsedLotto.DistinctNumbers
                from secondNum in parsedLotto.DistinctNumbers

                // Grabs a number and compares it to a second number to ensure they're not the same number.
                where firstNum.CompareTo(secondNum) < 0

                // Picks out all the potential number combinations and tosses it back to a pair list.
                select new Pairs {First = firstNum, Second = secondNum}).Cast<IPairs>().ToList();

            List<IPairs> pairList =
                (from l in parsedLotto.AllNumbers
                    from p in pairs

                    // Grabs each possible pair and the entire list of number arrays and finds where both numbers
                    // appear in each array for each number pair.
                    where l.Contains(p.First) && l.Contains(p.Second)
                    group l by p
                    into g
                    orderby g.Count() descending // Orders each pair combination found by descending frequency count.
                    select new Pairs
                    {
                        First = g.Key.First,
                        Second = g.Key.Second,
                        Frequency = g.Count()
                    }).Cast<IPairs>().ToList(); // Grabs each pair as a key and each count -- could list it here but if kept iEnumerable will only process when it's needed.

            // Don't know effect if more than one thing needs it. Does it do it every time where a list would be faster?

            _pairsJsonSerial.PairsSerializeAsync(lotteryName, pairList);
        }
    }
}