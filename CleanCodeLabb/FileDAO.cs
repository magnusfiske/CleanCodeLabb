using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb
{
    internal class FileDAO : IDAO
    {
        public string GenerateTopList()
        {
            List<PlayerData> results = LoadResults();
            results.Sort((p1, p2) => p1.CalculateAverage().CompareTo(p2.CalculateAverage()));
            string topList = "Player   games average\n";
            foreach (PlayerData p in results)
            {
                topList += string.Format("{0,-9}{1,5:D}{2,9:F2}", p.PlayerName, p.NumberOfGames, p.CalculateAverage() + "\n");
            }
            return topList;
        }

        public List<PlayerData> LoadResults()
        {
            try
            {
                StreamReader input = new StreamReader("result.txt");
                List<PlayerData> results = new List<PlayerData>();
                string? line;
                while ((line = input.ReadLine()) != null)
                {
                    string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                    string name = nameAndScore[0];
                    int guesses = Convert.ToInt32(nameAndScore[1]);
                    PlayerData pd = new PlayerData(name, guesses);
                    int pos = results.IndexOf(pd);
                    if (pos < 0)
                    {
                        results.Add(pd);
                    }
                    else
                    {
                        results[pos].Update(guesses);
                    }


                }
                input.Close();
                return results;
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
