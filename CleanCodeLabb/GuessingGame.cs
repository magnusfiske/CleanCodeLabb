﻿using System;
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
        private List<IGuessingGameStrategy> _strategyList = StrategyCreator.StrategyFactory();
        private IGuessingGameStrategy _strategy;

        public bool HasStrategyOptions { get; } = true;
        public int NumberOfGuesses { get; private set; }

        public string GetStrategy()
        {
            return _strategy.ToString();
        }

        public string GetStrategyOptions()
        {
            string strategyOptions = "Choose game: \n";
            for (int i = 0; i < _strategyList.Count; i++)
            {
                strategyOptions += $"{i}. {_strategyList[i].ToString()} \n";
            }
            return strategyOptions;
        }

        public void SetStrategy(int userInput)
        {
                _strategy = _strategyList[userInput];
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
