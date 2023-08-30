using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Update(int guesses)
        {
            TotalNumberOfGuesses += guesses;
            NumberOfGames++;
        }

        public double CalculateAverage()
        {
            return (double)TotalNumberOfGuesses / NumberOfGames;
        }

        
        public override bool Equals(Object player)
        {
            Player other = (Player)player;
            return PlayerName.Equals(other.PlayerName);
        }


        public override int GetHashCode()
        {
            return PlayerName.GetHashCode();
        }
    }
}
