using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb
{
    internal class PlayerData
    {
        int totalNumberOfGuesses;


        public PlayerData(string name, int guesses)
        {
            PlayerName = name;
            NumberOfGames = 1;
            totalNumberOfGuesses = guesses;
        }

        public string PlayerName { get; private set; }
        public int NumberOfGames { get; private set; }

        public void Update(int guesses)
        {
            totalNumberOfGuesses += guesses;
            NumberOfGames++;
        }

        public double CalculateAverage()
        {
            return (double)totalNumberOfGuesses / NumberOfGames;
        }

        
        public override bool Equals(Object p)
        {
            return PlayerName.Equals(((PlayerData)p).PlayerName);
        }


        public override int GetHashCode()
        {
            return PlayerName.GetHashCode();
        }
    }
}
