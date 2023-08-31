using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLabb.GameLogic;

namespace UnitTestsCleanCodeLabb
{
    [TestClass]
    public class MasterMindStrategyTest
    {
        private MasterMindStrategy _game;

        [TestInitialize]
        public void CreateGame()
        {
            _game = new MasterMindStrategy();
        }

        [DataTestMethod]
        [DataRow("1312", "1122", "RR,W")]
        [DataRow("1312", "3254", ",WW")]
        [DataRow("1312", "1312", "RRRR,")]
        public void TestCheckGameResult(string goal, string input, string expected)
        {
            string actual = _game.CheckGameResult(goal, input);


            Assert.AreEqual(expected, actual);
        }
    }
}
