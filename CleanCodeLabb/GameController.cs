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
        }


        public void Run()
        {
            InitializeGame();
            do
            {
                GameLoop();
            } while (CheckForUserContinue());
        }

        private void InitializeGame()
        {
            _ui.PutString("Enter your user name:\n");
            playerName = _ui.GetString();
            try
            {
                _ui.PutString(_game.GetStrategyOptions());
                int userGameChoice = int.Parse(_ui.GetString()[..1]);
                _game.SetStrategy(userGameChoice);
                _io.SetGameForResults(_game.GetStrategy());
            }
            catch(Exception e) 
            { 
                _ui.PutString(e.Message);
                Run();
            }
        }

        private void GameLoop()
        {
            _ui.PutString(_game.NewGame());
            _ui.PutString(_game.Cheat());
            string userGuess;
            do
            {
                userGuess = _game.ValidateUserInput(_ui.GetString().Trim());
                _ui.PutString(userGuess + "\n");
                _ui.PutString(_game.CheckResult(userGuess));

            } while (!_game.IsWin());
            _io.SaveResult(playerName, _game.NumberOfGuesses);
            _ui.PutString(_io.GenerateTopList());
            _ui.PutString(_game.CreateWinMessage());
        }


        private bool CheckForUserContinue()
        {
            string userContinueChoice  = _ui.GetString();

            if (string.IsNullOrEmpty(userContinueChoice) ||  userContinueChoice[..1] == "n")
            {
                return false;
            }
            return true;
        }
    }
}
