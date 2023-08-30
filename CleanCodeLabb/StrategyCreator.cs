using CleanCodeLabb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb
{
    static class StrategyCreator
    {
        public static List<IGuessingGameStrategy> StrategyFactory()
        {
            return new List<IGuessingGameStrategy> { new MooGameStrategy(), new MasterMindStrategy()};
        }
    }
}
