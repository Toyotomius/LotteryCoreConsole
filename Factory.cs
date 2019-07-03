using LotteryCoreConsole.FileManagement;
using LotteryCoreConsole.Interfaces;
using LotteryCoreConsole.PairsCode;
using LotteryCoreConsole.Settings;
using LotteryCoreConsole.SinglesCode;
using LotteryCoreConsole.TripletsCode;

namespace LotteryCoreConsole
{
    public static class Factory
    {
        internal static IBeginLottoCalculations CreateBeginLottoCalculations()
        {
            return new BeginLottoCalculations(CreateNumberParser(), CreateParaSingles(), CreateParaPairs(), CreateParaTriplets());
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

        internal static IBeginLottoCalculations CreateStartLottoLists()
        {
            return new BeginLottoCalculations(CreateNumberParser(), CreateParaSingles(),
                                                CreateParaPairs(), CreateParaTriplets());
        }

        internal static ISetSettings SetNewSettings()
        {
            return new SetSettings(CreateSettings(), CreateLogger());
        }

        private static IFileOut CreateFileOut()
        {
            return new FileOut();
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