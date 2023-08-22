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
        public string NewGame();
        public void CreateGameObjective();
        public void CheckGameResult(string guess);
        public string CreateWinMessage();
        public string Cheat();
    }
}
