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
        int NumberOfGuesses { get; }
        string GetStrategyOptions();
        void SetStrategy(int userInput);
        string NewGame();
        string ValidateUserInput(string input);
        string CheckResult(string guess);
        bool IsWin();
        string CreateWinMessage();
        string Cheat();
    }
}
