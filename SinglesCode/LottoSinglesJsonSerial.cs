using System.Collections.Generic;
using System.Threading.Tasks;

using LotteryCoreConsole.Interfaces;

namespace LotteryCoreConsole.SinglesCode
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

        public async Task SinglesSerializeAsync(string lotteryName, List<GetSetObjects.Singles> singlesList)
        {
            string singlesJson = _serializer.JSerialize(singlesList);

            await _singlesFileOut.WriteFileAsync(lotteryName, singlesJson);
        }
    }
}