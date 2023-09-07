using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb.GameLogic
{
    public class GuessingGame : IGame, ISubject
    {
        //public for testing access
        public string _gameObjective = string.Empty;
        private string _checkedGuess = string.Empty;
        private readonly List<IGuessingGameStrategy> _strategyList = StrategyCreator.CreateGameStrategies();
        private IGuessingGameStrategy _strategy;
        private List<IObserver> _observers = new List<IObserver>();

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

        public void SetStrategy(int userStrategyChoice)
        {
            _strategy = _strategyList[userStrategyChoice];
            Notify();
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
                if (_strategy.IsValidNumber(randomDigit, _gameObjective))
                {
                    _gameObjective += randomDigit;
                }
            }
        }

        private void ResetNumberOfGuesses()
        {
            NumberOfGuesses = 0;
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

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
