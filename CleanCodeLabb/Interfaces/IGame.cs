using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb.Interfaces
{
    internal interface IGame
    {
        string? CheckedGuess { get; }
        int NumberOfGuesses { get; }
        void SetStrategy(IGuessingGameStrategy strategy);
        string NewGame();
        void CheckResult(string guess);
        bool IsWin();
        string CreateWinMessage();
        string Cheat();
    }
}
