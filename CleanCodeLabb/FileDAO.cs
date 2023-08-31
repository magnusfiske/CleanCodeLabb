using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CleanCodeLabb.Interfaces;
using MongoDB.Bson.IO;

namespace CleanCodeLabb
{
    internal class FileDAO : IDAO
    {
        private string _separator = "#&#";
        private string _fileName;

        public void SetResultTable(string gameName)
        { 
            _fileName = gameName + "Results.txt"; 
        }

        public List<Player> ReadAll()
        {
            try
            {
                StreamReader input = new StreamReader(_fileName);
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

        public void Save(string playerName, int numberOfGuesses)
        {
            try
            {
                StreamWriter output = new StreamWriter(_fileName, append: true);
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

        public override string ToString()
        {
            return "Local file";
        }
    }
}
