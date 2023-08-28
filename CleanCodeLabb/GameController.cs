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
            initializeGame();
            do
            {
                gameLoop();
            } while (checkForUserContinue());
        }
        private void initializeGame()
        {
            ui.PutString("Enter your user name:\n");
            playerName = ui.GetString();
            ui.PutString(game.GetStrategyOptions());
            try
            {
                game.SetStrategy(ui.GetString().Substring(0, 1));
            }
            catch(Exception e) 
            { 
                ui.PutString(e.Message);
                Run();
            }
        }

        private void gameLoop()
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


        private bool checkForUserContinue()
        {
            string userInput  = ui.GetString();

            if (userInput == "" || userInput == null ||  userInput.Substring(0, 1) == "n")
            {
                return false;
            }
            return true;
        }
    }
}
