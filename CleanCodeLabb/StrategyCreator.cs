﻿using CleanCodeLabb.GameLogic;
using CleanCodeLabb.Interfaces;
using CleanCodeLabb.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CleanCodeLabb
{
    public class StrategyCreator
    {
        static T Instantiate<T>(Type t)
        {
            return (T)Activator.CreateInstance(t);
        }

        static bool IsStrategy<T>(Type t)
        {
            return typeof(T).IsAssignableFrom(t) && t.IsClass;
        }

        //Returns instances of all strategies in assembly
        public static List<IGuessingGameStrategy> CreateGameStrategies()
        {
            IEnumerable<Type> gameStrategyTypes = Assembly.GetExecutingAssembly().GetTypes().Where(IsStrategy<IGuessingGameStrategy>);
            return gameStrategyTypes.Select(Instantiate<IGuessingGameStrategy>).ToList();
        }
    }
}
