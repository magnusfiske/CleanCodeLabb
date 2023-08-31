using CleanCodeLabb.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SecurityToken.Model;

namespace CleanCodeLabb
{
    internal class MongoIO : IIO
    {
        private readonly MongoClient dbClient;
        private readonly IMongoDatabase database;
        private IMongoCollection<Player> players;

        public MongoIO(string connectionstring, string database)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionstring);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            dbClient = new MongoClient(settings);
            this.database = dbClient.GetDatabase(database);
        }
        public string GenerateTopList()
        {
            List<Player> results = LoadResults();
            List<Player> sortedResults = sortResults(results);

            return printTopList(sortedResults);

        }

        public List<Player> LoadResults()
        {
            var results = players.Find(new BsonDocument());
            return new List<Player>(results.ToList());
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
            Player player;
            if (hasPreviousResults(playerName))
            {
                player = GetPlayer(playerName);
                UpdatePlayer(player, numberOfGuesses);
            }
            else 
            {
                player = new Player(playerName, numberOfGuesses);
                players.InsertOne(player);
            }
        }

        private bool hasPreviousResults(string playerName)
        {
            return players.AsQueryable().Any(player => player.PlayerName == playerName);
        }

        private Player GetPlayer(string playerName)
        {
            var filter = Builders<Player>.Filter.Eq("PlayerName", playerName);
            return players.Find(filter).FirstOrDefault();
        }

        private UpdateResult UpdatePlayer(Player player, int numberOfGuesses)
        {
            var filter = Builders<Player>.Filter.Eq("_id", player.Id);
            var update = Builders<Player>.Update.Set("TotalNumberOfGuesses", player.TotalNumberOfGuesses + numberOfGuesses)
                                                .Set("NumberOfGames", player.NumberOfGames + 1);

            return players.UpdateOne(filter, update);
        }
        public void SetGameForResults(string gameName)
        {
            players = this.database.GetCollection<Player>(gameName);
        }

        
    }
}
