using CleanCodeLabb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb
{
    public class MooGameStrategy : IGuessingGameStrategy
    {
        public int NumberOfUniqueDigitsInObjective { get; } = 10;

        public bool IsValidNumber(string randomDigit, string gameObjective)
        {
            return !gameObjective.Contains(randomDigit);
        }

        public string CheckGameResult(string gameObjective, string guess)
        {
            int rightPlaceRightValue = 0;
            int wrongPlaceRightValue = 0;

            List<char> matchingItems = guess.Where(guessItem => gameObjective.Any(
                objectiveItem => guessItem == objectiveItem)).ToList();


            foreach (char c in matchingItems)
            {
                if (gameObjective.IndexOf(c) == guess.IndexOf(c))
                {
                    rightPlaceRightValue++;
                }
                else
                {
                    wrongPlaceRightValue++;
                }
            }

            return printCheckedGuess(rightPlaceRightValue, wrongPlaceRightValue);
        }

        private string printCheckedGuess(int rightPlaceRightValue, int wrongPlaceRightValue)
        {
            return "BBBB".Substring(0, rightPlaceRightValue) + "," + "CCCC".Substring(0, wrongPlaceRightValue);
        }
    }
}
