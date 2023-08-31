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
                int userInput = int.Parse(ui.GetString().Substring(0,1));
                game.SetStrategy(userInput);
                io.SetGameForResults(game.GetStrategy());
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
                input = game.ValidateUserInput(ui.GetString().Trim());
                ui.PutString(input + "\n");
                ui.PutString(game.CheckResult(input));

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
