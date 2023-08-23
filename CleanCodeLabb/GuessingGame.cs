using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb
{
    internal class GuessingGame : IGame
    {
        private string _gameObjective;
        //private int _rightPlaceRightValue, _wrongPlaceRightValue;
        private IGuessingGameStrategy _strategy;

        public string? CheckedGuess { get; private set; }
        public int NumberOfGuesses { get; private set; }

        public void SetStrategy(IGuessingGameStrategy? strategy)
        { 
            this._strategy = strategy; 
        }

        public string NewGame()
        {
            _gameObjective = string.Empty;
            CreateGameObjective();
            ResetNumberOfGuesses();
            return "New Game:\n";
        }

        private void CreateGameObjective()
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
        private void ResetNumberOfGuesses()
        {
            NumberOfGuesses = 0;
        }

        public void CheckResult(string guess)
        {
            NumberOfGuesses++;
            CheckedGuess = _strategy.CheckGameResult(_gameObjective, guess);
            
        }

        //private void CheckPositioning(char c, string guess)
        //{
        //    //Behöver göras om för Mastermind. gameObjective.IndexOf(c) hittar bara första förekomsten.
        //    if (_gameObjective.IndexOf(c) == guess.IndexOf(c))
        //    {
        //        _rightPlaceRightValue++;
        //    }
        //    else
        //    {
        //        _wrongPlaceRightValue++;
        //    }
        //}

        public bool IsWin()
        {
            //ObserverPattern??
            return CheckedGuess == "BBBB," || CheckedGuess == "RRRR,";
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
