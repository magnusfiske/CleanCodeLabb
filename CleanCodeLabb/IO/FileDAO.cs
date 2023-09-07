using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb.IO
{
    public class FileDAO : IDAO
    {
        private string _separator = "#&#";
        private string _fileName = string.Empty;

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
                    Player playerData = GetPlayerFromFile(fileContent);
                    AddOrUpdatePlayer(results, playerData);
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

        private Player GetPlayerFromFile(string fileContent)
        {
            string[] namesAndScores = SplitFileContentToArray(fileContent);
            string name = namesAndScores[0];
            int guesses = Convert.ToInt32(namesAndScores[1]);
            return new Player(name, guesses);
        }

        private List<Player> AddOrUpdatePlayer(List<Player> results, Player playerData)
        {
            int pos = results.IndexOf(playerData);
            if (pos < 0)
            {
                results.Add(playerData);
            }
            else
            {
                results[pos].UpdatePlayerRecord(playerData.TotalNumberOfGuesses);
            }
            return results;
        }

        private string[] SplitFileContentToArray(string fileContent)
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
