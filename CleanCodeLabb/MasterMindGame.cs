using CleanCodeLabb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb
{
    internal class MasterMindGame : IGame
    {
        private string gameObjective;
        public string? CheckedGuess { get; private set; }

        public int NumberOfGuesses { get; private set; }

        public string Cheat()
        {
            return gameObjective;
        }

        public void CheckGameResult(string guess)
        {
            throw new NotImplementedException();
        }

        public void CreateGameObjective()
        {
            throw new NotImplementedException();
        }

        public string CreateWinMessage()
        {
            throw new NotImplementedException();
        }

        public string NewGame()
        {
            throw new NotImplementedException();
        }
    }
}
