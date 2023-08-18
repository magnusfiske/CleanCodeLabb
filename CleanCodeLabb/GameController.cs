using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb
{
    internal class GameController
    {
        private IUI ui;
        private MooGame game;
        private string? playerName;
        private IDAO? dao;

        public GameController(IUI ui, MooGame game)
        {
            this.ui = ui;
            this.game = game;
        }

        public void Run()
        {
            NewGame();
            string input;
            do
            {
                Display();
                input = ui.GetString().Trim();

            } while (input.ToLower() != "q");
        }

        private void NewGame()
        {
            ui.PutString("Enter your user name:\n");
            playerName = ui.GetString();
        }

        private void Display()
        {
            ui.PutString("");
        }
    }
}
