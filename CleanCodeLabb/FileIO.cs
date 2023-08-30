using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb
{
    internal class FileIO : IIO
    {
        private string _separator = "#&#";
        public string GenerateTopList()
        {
            List<Player> resultsFromFile = LoadResults();
            List<Player> sortedResults = sortResults(resultsFromFile);
            
            return printTopList(sortedResults);
        }

        public List<Player> LoadResults()
        {
            try
            {
                StreamReader input = new StreamReader("result.txt");
                List<Player> results = new List<Player>();
                string? fileContent;

                while ((fileContent = input.ReadLine()) != null)
                {
                    Player playerData = getPlayerFromFile(fileContent);
                    addOrUpdatePlayer(results, playerData);
                }
                input.Close();
                return results;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Results file not found. " + e.Message);
                return new List<Player>();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return new List<Player>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Player>();
            }
        }

        private Player getPlayerFromFile(string fileContent)
        {
            string[] namesAndScores = splitFileContentToArray(fileContent);
            string name = namesAndScores[0];
            int guesses = Convert.ToInt32(namesAndScores[1]);
            return new Player(name, guesses);
        }

        private List<Player> addOrUpdatePlayer(List<Player> results, Player playerData)
        {
            int pos = results.IndexOf(playerData);
            if (pos < 0)
            {
                results.Add(playerData);
            }
            else
            {
                results[pos].Update(playerData.TotalNumberOfGuesses);
            }
            return results;
        }

        private string[] splitFileContentToArray(string fileContent)
        {
            return fileContent.Split(new string[] { _separator }, StringSplitOptions.None);
        }

        private List<Player> sortResults(List<Player> results)
        {
            results.Sort((p1, p2) => p1.CalculateAverage().CompareTo(p2.CalculateAverage()));
            return results;
        }

        private string printTopList(List<Player> sortedResults)
        {
            string topList = "Player     games     average\n";
            foreach (Player p in sortedResults)
            {
                topList += string.Format("{0,-9} {1,5:D} {2,9:F2}", p.PlayerName, p.NumberOfGames, p.CalculateAverage()) + "\n";
            }
            return topList;
        }

        public void SaveResult(string playerName, int numberOfGuesses)
        {
            try
            {
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(playerName + _separator + numberOfGuesses);
                output.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
