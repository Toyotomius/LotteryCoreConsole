using LotteryCoreConsole.Interfaces;

namespace LotteryCoreConsole.GetSetObjects
{
    public class Pairs : Singles, IPairs
    {
        public int Second { get; set; }
    }
}