using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb
{
    internal class MooGame : IGame
    {
        private string gameObjective;
        private int cows, bulls;

        public string? CheckedGuess { get; private set; }
        public int NumberOfGuesses { get; private set; }

        public string NewGame()
        {
            gameObjective = string.Empty;
            CreateGameObjective();
            ResetNumberOfGuesses();
            return "New Game:\n";
        }

        public void CreateGameObjective()
        {
            Random randomGenerator = new Random();
            while (gameObjective.Length < 4)
            {
                string randomDigit = randomGenerator.Next(10).ToString();
                if (!gameObjective.Contains(randomDigit)) 
                {
                    gameObjective += randomDigit; 
                }
            }
        }
        private void ResetNumberOfGuesses()
        {
            NumberOfGuesses = 0;
        }

        public void CheckGameResult(string guess)
        {
            NumberOfGuesses++;
            cows = 0; 
            bulls = 0;

            var matchingNumbers = guess.Where(guessItem => 
                 gameObjective.Any(objItem => guessItem == objItem)).ToList();

            foreach (char c in matchingNumbers)
            {
                TranslateToBullsAndCows(c, guess);
            }
            
            CheckedGuess = "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }

        private void TranslateToBullsAndCows(char c, string guess)
        {
            if (gameObjective.IndexOf(c) == guess.IndexOf(c))
            {
                bulls++;
            }
            else
            {
                cows++;
            }
        }

        public string CreateWinMessage()
        {
            return "Correct, it took " + NumberOfGuesses + " guesses\nContinue?";
        }

        public string Cheat()
        {
            return gameObjective;
        }

    }
}
