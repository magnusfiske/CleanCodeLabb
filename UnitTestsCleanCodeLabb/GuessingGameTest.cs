using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestsCleanCodeLabb
{
    [TestClass]
    public class GuessingGameTest
    {
        private GuessingGame _guessingGame;

        [TestInitialize]
        public void createGame()
        {
            this._guessingGame= new GuessingGame();
        }

        [TestMethod]
        public void testMasterMindNewGame()
        {
            _guessingGame.SetStrategy("2");
            _guessingGame.NewGame();

            Regex regex = new Regex("^[0-5]{4}$");

            StringAssert.Matches(_guessingGame._gameObjective, regex);
        }

        [TestMethod]
        public void testMooNewGame()
        {
            _guessingGame.SetStrategy("1");
            _guessingGame.NewGame();

            Regex regex = new Regex(@"^(?!.*(.).*\1)\d{4}$");

            StringAssert.Matches(_guessingGame._gameObjective, regex);
        }
    }
}
