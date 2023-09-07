using CleanCodeLabb.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCleanCodeLabb
{
    [TestClass]
    public class ioHandlerTest
    {
        private ioHandler _handler;

        [TestInitialize]
        public void CreateIoHandler()
        {
            _handler = new ioHandler(new MockFileService());
        }

        [TestMethod]
        public void TestGenerateTopList() 
        {
            string actual = _handler.GenerateTopList();
            string expected = "Player     games     average\n" + string.Format("{0,-9} {1,5:D} {2,9:F2}", "testPlayer2", "2", "9,00") + "\n" + string.Format("{0,-9} {1,5:D} {2,9:F2}", "testPlayer1", "3", "10,67") + "\n";

            Assert.AreEqual(expected, actual);
        }
    }
}
