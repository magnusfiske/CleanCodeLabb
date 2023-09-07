using CleanCodeLabb.GameLogic;
using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb.IO
{
    public class ioHandler : IIO
    {
        private IIoService _ioService;

        public ioHandler(IIoService ioService)
        {
            _ioService = ioService;
        }

        public string GenerateTopList()
        {
            List<Player> results = _ioService.ReadAll();
            List<Player> sortedResults = SortResults(results);

            return PrintTopList(sortedResults);
        }

        private List<Player> SortResults(List<Player> results)
        {
            results.Sort((p1, p2) => p1.CalculateAverageNumberOfGuesses().CompareTo(p2.CalculateAverageNumberOfGuesses()));
            return results;
        }

        private string PrintTopList(List<Player> sortedResults)
        {
            string topList = "Player     games     average\n";
            foreach (Player p in sortedResults)
            {
                topList += string.Format("{0,-9} {1,5:D} {2,9:F2}", p.PlayerName, p.NumberOfGames, p.CalculateAverageNumberOfGuesses()) + "\n";
            }
            return topList;
        }

        public void SaveResult(string playerName, int numberOfGuesses)
        {
            _ioService.Save(playerName, numberOfGuesses);
        }

        public void SetGameForResults(string gameName)
        {
            _ioService.SetResultTable(gameName);
        }
    }
}
