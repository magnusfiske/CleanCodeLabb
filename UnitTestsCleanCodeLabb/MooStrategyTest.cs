using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCleanCodeLabb
{
    [TestClass]
    public class MooStrategyTest
    {
        private MooGameStrategy _game;

        [TestInitialize]
        public void CreateGame()
        {
            _game = new MooGameStrategy();
        }
        
        [DataTestMethod]
        [DataRow("1312", "1425", "B,C")]
        [DataRow("1312", "3254", ",CC")]
        [DataRow("1312", "1312", "BBBB,")]
        public void TestCheckGameResult(string goal, string input, string expected)
        {
            string actual = _game.CheckGameResult(goal, input);


            Assert.AreEqual(expected, actual);
        }
    }
}
