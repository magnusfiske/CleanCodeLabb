using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb
{
    public class GuessingGame : IGame
    {
        public string _gameObjective;
        private string _checkedGuess;
        private IGuessingGameStrategy _strategy;

        public bool HasStrategyOptions { get; } = true;
        public int NumberOfGuesses { get; private set; }

        public string GetStrategyOptions()
        {
            return "Choose game: \n1. Moo \n2. Master Mind";
        }

        public void SetStrategy(string userInput)
        { 
            if (userInput == "1")
            {
                _strategy = new MooGameStrategy(); 
            }
            else if (userInput == "2")
            {
                _strategy = new MasterMindStrategy();
            }
            else
            {
                throw new NotImplementedException("No game matching request found");
            }
            
        }

        public string NewGame()
        {
            _gameObjective = string.Empty;
            createGameObjective();
            resetNumberOfGuesses();
            return "New Game:\n";
        }

        private void createGameObjective()
        {
            Random randomGenerator = new Random();
            while (_gameObjective?.Length < 4)
            {
                string randomDigit = randomGenerator.Next(_strategy.NumberOfUniqueDigitsInObjective).ToString();
                if (_strategy.IsValidNumber(randomDigit,_gameObjective))
                {
                    _gameObjective += randomDigit;
                }
            }
        }

        public string ValidateUserInput(string input)
        {
            int lengthOfValidGuess = 4;
            if (input.Length < lengthOfValidGuess)
            {
                input += "    ";
            }
            return input.Remove(lengthOfValidGuess);
        }

        private void resetNumberOfGuesses()
        {
            NumberOfGuesses = 0;
        }

        public string CheckResult(string guess)
        {
            NumberOfGuesses++;
            _checkedGuess = _strategy.CheckGameResult(_gameObjective, guess);
            return _checkedGuess;
            
        }

        public bool IsWin()
        {
            //ObserverPattern??
            return _checkedGuess == "BBBB," || _checkedGuess == "RRRR,";
        }

        public string CreateWinMessage()
        {
            return "Correct, it took " + NumberOfGuesses + " guesses\nContinue?";
        }

        public string Cheat()
        {
            return _gameObjective;
        }

    }
}
