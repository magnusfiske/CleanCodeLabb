using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb
{
    internal class GameController
    {
        private readonly IUI _ui;
        private readonly IGame _game;
        private readonly IIO _io;
        private string playerName = string.Empty;

        public GameController(IUI ui, IGame game, IIO io)
        {
            _ui = ui;
            _game = game;
            _io = io;
            (_game as ISubject).Attach(_io as IObserver); //Lämpligt ställa att ha den??
        }


        public void Run()
        {
            initializeGame();
            do
            {
                gameLoop();
            } while (checkForUserContinue());
        }

        private void initializeGame()
        {
            _ui.PutString("Enter your user name:\n");
            playerName = _ui.GetString();
            _ui.PutString(_io.GetIoStrategyOptions());
            try
            {
                int userIoChoice = int.Parse(_ui.GetString()[..1]);
                _io.SetIoStrategy(userIoChoice);
                _ui.PutString(_game.GetStrategyOptions());
                int userGameChoice = int.Parse(_ui.GetString()[..1]);
                _game.SetStrategy(userGameChoice);
            }
            catch(Exception e) 
            { 
                _ui.PutString(e.Message);
                Run();
            }
        }

        private void gameLoop()
        {
            _ui.PutString(_game.NewGame());
            _ui.PutString(_game.Cheat());
            string input;
            do
            {
                input = _game.ValidateUserInput(_ui.GetString().Trim());
                _ui.PutString(input + "\n");
                _ui.PutString(_game.CheckResult(input));

            } while (!_game.IsWin());
            _io.SaveResult(playerName, _game.NumberOfGuesses);
            _ui.PutString(_io.GenerateTopList());
            _ui.PutString(_game.CreateWinMessage());
        }


        private bool checkForUserContinue()
        {
            string userInput  = _ui.GetString();

            if (string.IsNullOrEmpty(userInput) ||  userInput[..1] == "n")
            {
                return false;
            }
            return true;
        }
    }
}
