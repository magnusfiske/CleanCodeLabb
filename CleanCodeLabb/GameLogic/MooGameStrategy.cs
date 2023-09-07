using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb.GameLogic
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
                    gameObjective = gameObjective.Replace(c, '-');
                }
                else
                {
                    wrongPlaceRightValue++;
                }
            }

            return PrintCheckedGuess(rightPlaceRightValue, wrongPlaceRightValue);
        }

        private string PrintCheckedGuess(int rightPlaceRightValue, int wrongPlaceRightValue)
        {
            return "BBBB".Substring(0, rightPlaceRightValue) + "," + "CCCC".Substring(0, wrongPlaceRightValue);
        }

        public override string ToString()
        {
            return "Moo";
        }
    }
}
