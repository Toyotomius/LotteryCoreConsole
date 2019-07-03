﻿using System.Collections.Generic;

namespace LotteryCoreConsole.Interfaces
{
    public interface IParaTriplets
    {
        void FindTripsParallel(string lotteryName, (IEnumerable<int[]> AllNumbers, IEnumerable<int> DistinctNumbers) parsedLotto);
    }
}