using System.Collections.Generic;
using System.Threading.Tasks;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.Lottery_Calculation.SinglesCode
{
    public class LottoBonusJsonSerial : ILottoBonusJsonSerial
    {
        private readonly IListJsonSerializer _serializer;

        private readonly ILottoBonusFileOut _bonusFileOut;

        public LottoBonusJsonSerial(IListJsonSerializer serializer, ILottoBonusFileOut bonusFileOut)
        {
            _serializer = serializer;
            _bonusFileOut = bonusFileOut;
        }

        public async Task BonusSerializeAsync(string lotteryName, IList<ISingles> bonusList)
        {
            string bonusJson = _serializer.JSerialize(bonusList);

            await _bonusFileOut.WriteFileAsync(lotteryName, bonusJson);
        }
    }
}