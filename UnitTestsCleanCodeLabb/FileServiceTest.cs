using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLabb.IO;
using DnsClient;

namespace UnitTestsCleanCodeLabb
{
    [TestClass]
    public class FileServiceTest
    {
        FileService _service;

        [TestInitialize]
        public void CreateFileDAOAndMockFile()
        {
            _service = new FileService();
            _service.SetResultTable("test");
        }

        [TestMethod]
        public void TestSaveAndReadOnePlayerOneGame()
        {
            _service.Save("testPlayer", 5);

            List<Player> actual = _service.GetAllResults();

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("testPlayer", actual[0].PlayerName);
            Assert.AreEqual(5, actual[0].TotalNumberOfGuesses);
        }

        [TestMethod]
        public void TestUpdatePlayer() 
        {
            _service.Save("testPlayer", 5);
            _service.Save("testPlayer", 7);

            List<Player> actual = _service.GetAllResults();

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("testPlayer", actual[0].PlayerName);
            Assert.AreEqual(12, actual[0].TotalNumberOfGuesses);
        }

        [TestMethod]
        public void TestSaveAndReadMultiplePlayers()
        {
            _service.Save("testPlayer", 5);
            _service.Save("testPlayer2", 7);
            _service.Save("testPlayer", 7);
            _service.Save("testPlayer2", 8);


            List<Player> actual = _service.GetAllResults();

            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("testPlayer2", actual[1].PlayerName);
            Assert.AreEqual(15, actual[1].TotalNumberOfGuesses);
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete("testResults.txt");
        }
    }
}
