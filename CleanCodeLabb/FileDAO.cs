using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanCodeLabb
{
    internal class FileDAO : IDAO
    {
        public void LoadResult()
        {
            try
            {
                StreamReader input = new StreamReader("result.txt");
                List<PlayerData> results = new List<PlayerData>();
            }
            catch
            {
                throw new IOException();
            }
        }

        public void SaveResult(string playerName, int numberOfGuesses)
        {
            try
            {
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(playerName + "#&#" + numberOfGuesses);
                output.Close();
            }
            catch 
            {
                throw new IOException();
            }
        }
    }
}
