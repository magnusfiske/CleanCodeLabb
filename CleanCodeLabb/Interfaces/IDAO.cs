using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb.Interfaces
{
    internal interface IDAO
    {
        public string GenerateTopList();
        public List<PlayerData> LoadResults();
        public void SaveResult(string playerName, int numberOfGuesses);
    }
}
