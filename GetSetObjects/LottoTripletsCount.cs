using LotteryCoreConsole.Interfaces;

namespace LotteryCoreConsole.GetSetObjects
{
    public class Triplets : Pairs, ITriplets
    {
        public int Third { get; set; }
    }
}