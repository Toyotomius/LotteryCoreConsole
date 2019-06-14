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
        public static IFileOut CreateFileOut()
        {
            return new FileOut();
        }

        public static IListJsonSerializer CreateJsonSerializer()
        {
            return new ListJsonSerializer();
        }

        public static ILogging CreateLogger()
        {
            return new Logging();
        }

        public static IMakeLottoList CreateLottoList()
        {
            return new MakeLottoList();
        }

        public static INumberParsing CreateNumberParser()
        {
            return new NumberParsing();
        }

        public static ILottoPairsFileOut CreatePairsFileOut()
        {
            return new LottoPairsFileOut(CreateFileOut());
        }

        public static ILottoPairsJsonSerial CreatePairsJsonSerial()
        {
            return new LottoPairsJsonSerial(CreateJsonSerializer(), CreatePairsFileOut());
        }

        public static IParaPairs CreateParaPairs()
        {
            return new ParaPairs(CreatePairsJsonSerial());
        }

        public static IParaSingles CreateParaSingles()
        {
            return new ParaSingles(CreateSinglesJSonSerial());
        }

        public static IParaTriplets CreateParaTriplets()
        {
            return new ParaTriplets(CreateTripsJsonSerial());
        }

        public static ISettings CreateSettings()
        {
            return new Settings.Settings();
        }

        public static ILottoSinglesFileOut CreateSinglesFileOut()
        {
            return new LottoSinglesFileOut(CreateFileOut());
        }

        public static ILottoSinglesJsonSerial CreateSinglesJSonSerial()
        {
            return new LottoSinglesJsonSerial(CreateJsonSerializer(), CreateSinglesFileOut());
        }

        public static IBeginLottoCalculations CreateStartLottoLists()
        {
            return new BeginLottoCalculations(CreateNumberParser(), CreateParaSingles(),
                                                CreateParaPairs(), CreateParaTriplets());
        }

        public static ILottoTripsFileOut CreateTripsFileOut()
        {
            return new LottoTripsFileOut(CreateFileOut());
        }

        public static ILottoTripsJsonSerial CreateTripsJsonSerial()
        {
            return new LottoTripsJsonSerial(CreateJsonSerializer(), CreateTripsFileOut());
        }

        public static ISetSettings SetNewSettings()
        {
            return new SetSettings(CreateSettings(), CreateLogger());
        }
    }
}