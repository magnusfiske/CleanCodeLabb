using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb
{
    internal interface IDAO
    {
        public void SaveResult(string playerName, int numberOfGuesses);
        public void LoadResult();
    }
}
