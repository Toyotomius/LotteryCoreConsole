using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotteryCoreConsole.Lottery_Calculation.Interfaces
{
    public interface ILottoBonusJsonSerial
    {
        Task BonusSerializeAsync(string lotteryName, IList<ISingles> bonusList);
    }
}