using System.Collections.Generic;
using System.Threading.Tasks;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.Lottery_Calculation.SinglesCode
{
    public class LottoSinglesJsonSerial : ILottoSinglesJsonSerial
    {
        private readonly IListJsonSerializer _serializer;

        private readonly ILottoSinglesFileOut _singlesFileOut;

        public LottoSinglesJsonSerial(IListJsonSerializer serializer, ILottoSinglesFileOut singlesFileOut)
        {
            _serializer = serializer;
            _singlesFileOut = singlesFileOut;
        }

        public async Task SinglesSerializeAsync(string lotteryName, IList<ISingles> singlesList)
        {
            string singlesJson = _serializer.JSerialize(singlesList);

            await _singlesFileOut.WriteFileAsync(lotteryName, singlesJson);
        }
    }
}