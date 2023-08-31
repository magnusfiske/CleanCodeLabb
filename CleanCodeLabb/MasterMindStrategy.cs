using CleanCodeLabb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb
{
    public class MasterMindStrategy : IGuessingGameStrategy
    {
        private string _gameObjective;
        private string _guess;
        private int _rightPlaceRightValue = 0;
        private int _wrongPlaceRightValue = 0;
        private int[] _checkedObjectivePositions = { -1, -1, -1, -1 };
        private int[] _checkedGuessPositions = { -1, -1, -1, -1 };
        private int _iteration;
        public int NumberOfUniqueDigitsInObjective { get; } = 6;

        public bool IsValidNumber(string randomDigit, string gameObjective)
        {
            return true;
        }

        public string CheckGameResult(string gameObjective, string guess)
        {
            _gameObjective = gameObjective;
            _guess = guess;
            resetCounters();

            countRightPlaceRightValue();
            countWrongPlaceRightValue();

            return printCheckedGuess(_rightPlaceRightValue, _wrongPlaceRightValue);
        }

        private void resetCounters()
        {
            _iteration = 0;
            _rightPlaceRightValue = 0;
            _wrongPlaceRightValue = 0;

            for (int i = 0; i < 4; i++)
            {
                _checkedObjectivePositions[i] = -1;
                _checkedGuessPositions[i] = -1;
            }
        }

        private void countRightPlaceRightValue()
        {
            for (int i = 0; i < 4; i++)
            {
                bool isRightPlaceRightValue = _guess[i] == _gameObjective[i];
                if (isRightPlaceRightValue)
                {
                    _rightPlaceRightValue++;
                    _checkedGuessPositions[i] = 1;
                    _checkedObjectivePositions[i] = 1;
                }
            }
        }

        private void countWrongPlaceRightValue()
        {
            for (int i = 0; i < 4; i++)
            {
                bool isWrongPlaceRightValue = _guess[i] == _gameObjective[_iteration] && _checkedGuessPositions[i] < 0 && _checkedObjectivePositions[_iteration] < 0;
                if (isWrongPlaceRightValue)
                {
                    _wrongPlaceRightValue++;
                    _checkedGuessPositions[i] = 1;
                    _checkedObjectivePositions[_iteration] = 1;
                }
            }
            _iteration++;
            if (_iteration < 4)
            {
                countWrongPlaceRightValue();
            }
        }

        private string printCheckedGuess(int rightPlaceRightValue, int wrongPlaceRightValue)
        {
            return "RRRR".Substring(0, rightPlaceRightValue) + "," + "WWWW".Substring(0, wrongPlaceRightValue);
        }

        public override string ToString()
        {
            return "MasterMind";
        }
    }
}
