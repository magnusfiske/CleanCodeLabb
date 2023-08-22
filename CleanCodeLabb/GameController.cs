using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb
{
    internal class GameController
    {
        private IUI ui;
        private IGame game;
        private string? playerName;
        private IDAO dAO;

        public GameController(IUI ui, IGame game, IDAO dAO)
        {
            this.ui = ui;
            this.game = game;
            this.dAO = dAO;
        }

        private void SetCurrentGame(IGame game)
        {
            this.game = game;
        }

        public void Run()
        {
            InitializeGame();
            do
            {
                GameLoop();
            } while (CheckForUserQuit());
        }

        private void GameLoop()
        {
            ui.PutString(game.NewGame());
            ui.PutString(game.Cheat());
            string input;
            do
            {
                input = ui.GetString().Trim();
                ui.PutString(input + "\n");
                game.CheckGameResult(input);
                ui.PutString(game.CheckedGuess + "\n");

            } while (game.CheckedGuess != "BBBB,");
            dAO.SaveResult(playerName, game.NumberOfGuesses);
            ui.PutString(dAO.GenerateTopList());
            ui.PutString(game.CreateWinMessage());
        }

        private void InitializeGame()
        {
            ui.PutString("Enter your user name:\n");
            playerName = ui.GetString();
            ui.PutString("Choose game: \n1. Moo \n2. Master Mind");
            if (ui.GetString().Substring(0,1) == "1")
            {
                SetCurrentGame(new MooGame());
            }
            else
            {
                SetCurrentGame(new MasterMindGame());
            }
        }

        private bool CheckForUserQuit()
        {
            string userInput  = ui.GetString();

            if (userInput.Substring(0, 1) == "n" || userInput == null || userInput == "")
            {
                return false;
            }
            return true;
        }
    }
}
