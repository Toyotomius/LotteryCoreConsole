using LotteryCoreConsole.FileManagement;
using LotteryCoreConsole.Lottery_Calculation;
using LotteryCoreConsole.Lottery_Calculation.Interfaces;
using LotteryCoreConsole.Lottery_Calculation.PairsCode;
using LotteryCoreConsole.Lottery_Calculation.SinglesCode;
using LotteryCoreConsole.Lottery_Calculation.TripletsCode;
using LotteryCoreConsole.Settings;

namespace LotteryCoreConsole
{
    public static class Factory
    {
        public static IFileOut CreateFileOut()
        {
            return new FileOut();
        }

        public static IValidateLottoLists CreateValidateLottoLists()
        {
            return new ValidateLottoLists(CreateBeginLottoCalculations());
        }

        internal static IBeginLottoCalculations CreateBeginLottoCalculations()
        {
            return new BeginLottoCalculations(CreateNumberParser(), CreateParaSingles(), CreateParaPairs(), CreateParaTriplets(), CreateParaBonus());
        }

        internal static IGetSettings CreateGetSettings()
        {
            return new GetSettings(SetNewSettings());
        }

        internal static ILogging CreateLogger()
        {
            return new Logging();
        }

        internal static IMakeLottoList CreateLottoList()
        {
            return new MakeLottoList();
        }

        internal static ISetSettings SetNewSettings()
        {
            return new SetSettings(CreateSettings(), CreateLogger());
        }

        private static IListJsonSerializer CreateJsonSerializer()
        {
            return new ListJsonSerializer();
        }

        private static INumberParsing CreateNumberParser()
        {
            return new NumberParsing();
        }

        private static ILottoPairsFileOut CreatePairsFileOut()
        {
            return new LottoPairsFileOut(CreateFileOut());
        }

        private static ILottoPairsJsonSerial CreatePairsJsonSerial()
        {
            return new LottoPairsJsonSerial(CreateJsonSerializer(), CreatePairsFileOut());
        }

        private static IParaBonus CreateParaBonus()
        {
            return new ParaBonus(CreateBonusJSonSerial());
        }
        private static ILottoBonusFileOut CreateBonusFileOut()
        {
            return new LottoBonusFileOut(CreateFileOut());
        }

        private static ILottoBonusJsonSerial CreateBonusJSonSerial()
        {
            return new LottoBonusJsonSerial(CreateJsonSerializer(), CreateBonusFileOut());
        }

        private static IParaPairs CreateParaPairs()
        {
            return new ParaPairs(CreatePairsJsonSerial());
        }

        private static IParaSingles CreateParaSingles()
        {
            return new ParaSingles(CreateSinglesJSonSerial());
        }

        private static IParaTriplets CreateParaTriplets()
        {
            return new ParaTriplets(CreateTripsJsonSerial());
        }

        private static ISettings CreateSettings()
        {
            return new Settings.Settings();
        }

        private static ILottoSinglesFileOut CreateSinglesFileOut()
        {
            return new LottoSinglesFileOut(CreateFileOut());
        }

        private static ILottoSinglesJsonSerial CreateSinglesJSonSerial()
        {
            return new LottoSinglesJsonSerial(CreateJsonSerializer(), CreateSinglesFileOut());
        }

        private static ILottoTripsFileOut CreateTripsFileOut()
        {
            return new LottoTripsFileOut(CreateFileOut());
        }

        private static ILottoTripsJsonSerial CreateTripsJsonSerial()
        {
            return new LottoTripsJsonSerial(CreateJsonSerializer(), CreateTripsFileOut());
        }
    }
}
