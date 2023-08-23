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
        private IIO io;

        public GameController(IUI ui, IGame game, IIO io)
        {
            this.ui = ui;
            this.game = game;
            this.io = io;
        }

        public void Run()
        {
            InitializeGame();
            do
            {
                GameLoop();
            } while (CheckForUserQuit());
        }
        private void InitializeGame()
        {
            ui.PutString("Enter your user name:\n");
            playerName = ui.GetString();
            ui.PutString("Choose game: \n1. Moo \n2. Master Mind");
            if (ui.GetString().Substring(0,1) == "1")
            {
                game.SetStrategy(new MooGameStrategy());
            }
            else
            {
                game.SetStrategy(new MasterMindStrategy());
            }
        }

        private void GameLoop()
        {
            ui.PutString(game.NewGame());
            ui.PutString(game.Cheat());
            string input;
            do
            {
                input = ui.GetString().Trim().Remove(4);
                ui.PutString(input + "\n");
                game.CheckResult(input);
                ui.PutString(game.CheckedGuess + "\n");

            } while (!game.IsWin());
            io.SaveResult(playerName, game.NumberOfGuesses);
            ui.PutString(io.GenerateTopList());
            ui.PutString(game.CreateWinMessage());
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
