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

namespace CleanCodeLabb.IO
{
    internal class MongoDAO : IDAO
    {
        private readonly MongoClient dbClient;
        private readonly IMongoDatabase database;
        private IMongoCollection<Player>? players;

        public MongoDAO(string connectionstring, string database)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionstring);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            dbClient = new MongoClient(settings);
            this.database = dbClient.GetDatabase(database);
        }

        public List<Player> ReadAll()
        {
            var results = players.Find(new BsonDocument());
            return new List<Player>(results.ToList());
        }

        public void Save(string playerName, int numberOfGuesses)
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

        public void SetResultTable(string gameName)
        {
            players = database.GetCollection<Player>(gameName);
        }

        public override string ToString()
        {
            return "MongoDb";
        }
    }
}
