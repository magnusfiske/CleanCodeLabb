using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb.Interfaces
{
    internal interface IIO
    {
        void SetGameForResults(string gameName);
        string GenerateTopList();
        List<Player> LoadResults();
        void SaveResult(string playerName, int numberOfGuesses);
    }
}
