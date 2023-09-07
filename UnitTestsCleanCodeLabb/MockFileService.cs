using CleanCodeLabb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCleanCodeLabb
{
    internal class MockFileService : IIoService
    {
        private List<Player> _players;

        public MockFileService() 
        {
            _players = new List<Player>();
            Player testPlayer1 = new Player("testPlayer1", 14);
            Player testPlayer2 = new Player("testPlayer2", 9);
            testPlayer1.UpdatePlayerRecord(10);
            testPlayer1.UpdatePlayerRecord(8);
            testPlayer2.UpdatePlayerRecord(9);
            _players.Add(testPlayer1);
            _players.Add(testPlayer2);
        }


        public List<Player> GetAllResults()
        {
            return _players;
        }

        public void Save(string playerName, int numberOfGuesses)
        {
            throw new NotImplementedException();
        }

        public void SetResultTable(string gameName)
        {
            throw new NotImplementedException();
        }
    }
}
