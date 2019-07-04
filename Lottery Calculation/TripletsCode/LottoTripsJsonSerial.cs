using System.Collections.Generic;
using System.Threading.Tasks;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;

namespace LotteryCoreConsole.Lottery_Calculation.TripletsCode
{
    public class LottoTripsJsonSerial : ILottoTripsJsonSerial
    {
        private readonly IListJsonSerializer _serializer;

        private readonly ILottoTripsFileOut _tripsFileOut;

        public LottoTripsJsonSerial(IListJsonSerializer serializer, ILottoTripsFileOut tripsFileOut)
        {
            _serializer = serializer;
            _tripsFileOut = tripsFileOut;
        }

        public async Task TripsSerializeAsync(string lotteryName, IList<ITriplets> tripletList)
        {
            string tripsJson = _serializer.JSerialize(tripletList);

            await _tripsFileOut.WriteFileAsync(lotteryName, tripsJson);
        }
    }
}