using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb.Interfaces
{
    internal interface IDAO
    {
        List<Player> ReadAll();
        void Save(string playerName, int numberOfGuesses);
        void SetResultTable(string gameName);
    }
}
