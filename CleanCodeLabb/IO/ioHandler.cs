using CleanCodeLabb.GameLogic;
using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb.IO
{
    internal class ioHandler : IIO, IObserver
    {
        private IDAO _ioStrategy;
        private List<IDAO> _ioList = StrategyCreator.IoStrategyFactory();

        public string GetIoStrategyOptions()
        {
            string strategyOptions = "Save results to: \n";
            for (int i = 0; i < _ioList.Count; i++)
            {
                strategyOptions += $"{i}. {_ioList[i].ToString()} \n";
            }
            return strategyOptions;
        }
        public void SetIoStrategy(int userInput)
        {
            _ioStrategy = _ioList[userInput];
        }
        public string GenerateTopList()
        {
            List<Player> results = _ioStrategy.ReadAll();
            List<Player> sortedResults = sortResults(results);

            return printTopList(sortedResults);
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
            _ioStrategy.Save(playerName, numberOfGuesses);
        }

        public void SetGameForResults(string gameName)
        {
            _ioStrategy.SetResultTable(gameName);
        }

        public void Update(ISubject subject)
        {
            _ioStrategy.SetResultTable((subject as GuessingGame).GetStrategy());
        }
    }
}
