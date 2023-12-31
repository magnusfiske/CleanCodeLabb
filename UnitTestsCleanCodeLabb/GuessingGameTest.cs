﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CleanCodeLabb.GameLogic;

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
        public void testMasterCreateGameObjective()
        {
            _guessingGame.SetStrategy(0);
            _guessingGame.NewGame();

            Regex regex = new Regex("^[0-5]{4}$");

            StringAssert.Matches(_guessingGame._gameObjective, regex);
        }

        [TestMethod]
        public void testMooCreateGameObjective()
        {
            _guessingGame.SetStrategy(1);
            _guessingGame.NewGame();

            Regex regex = new Regex(@"^(?!.*(.).*\1)\d{4}$");

            StringAssert.Matches(_guessingGame._gameObjective, regex);
        }
    }
}
