using CleanCodeLabb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb.GameLogic
{
    static class StrategyCreator
    {
        public static List<IGuessingGameStrategy> GameStrategyFactory()
        {
            return new List<IGuessingGameStrategy> { new MooGameStrategy(), new MasterMindStrategy() };
        }

        public static List<IDAO> IoStrategyFactory()
        {
            return new List<IDAO> { new FileDAO(),
                new MongoDAO("mongodb+srv://magnusfiske:supersecretPassWord@clusterfiske.8tkqxzs.mongodb.net/?retryWrites=true&w=majority", "GameResults") };
        }
    }
}
