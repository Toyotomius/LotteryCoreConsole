namespace LotteryCoreConsole.Interfaces
{
    public interface ILottoData
    {
        string Date { get; set; }

        int[] Numbers { get; set; }
    }
}