using MongoDB.Bson;

namespace CleanCodeLabb
{
    public class Player
    {
        public Player(string name, int guesses)
        {
            PlayerName = name;
            NumberOfGames = 1;
            TotalNumberOfGuesses = guesses;
        }

        public int TotalNumberOfGuesses { get; private set; }
        public string PlayerName { get; private set; }
        public int NumberOfGames { get; private set; }

        public void UpdatePlayerRecord(int guesses)
        {
            TotalNumberOfGuesses += guesses;
            NumberOfGames++;
        }

        public double CalculateAverageNumberOfGuesses()
        {
            return (double)TotalNumberOfGuesses / NumberOfGames;
        }

        public override bool Equals(Object player)
        {
            Player other = (Player)player;
            return PlayerName.Equals(other.PlayerName);
        }

        //public override int GetHashCode()
        //{
        //    return PlayerName.GetHashCode();
        //}
    }
}
