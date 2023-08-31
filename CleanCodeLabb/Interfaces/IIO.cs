using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb.Interfaces
{
    internal interface IIO
    {
        void SetIoStrategy(int input);
        string GetIoStrategyOptions();
        void SetGameForResults(string gameName);
        string GenerateTopList();
        void SaveResult(string playerName, int numberOfGuesses);
    }
}
