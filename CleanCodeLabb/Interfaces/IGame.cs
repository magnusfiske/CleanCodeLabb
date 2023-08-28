using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb.Interfaces
{
    internal interface IGame
    {
        bool HasStrategyOptions { get; }
        string? CheckedGuess { get; }
        int NumberOfGuesses { get; }
        string GetStrategyOptions();
        void SetStrategy(string userInput);
        string NewGame();
        void CheckResult(string guess);
        bool IsWin();
        string CreateWinMessage();
        string Cheat();
    }
}
