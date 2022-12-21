using Heathstone.Models;
using MongoDB.Driver;
using System.Text.Json;

namespace Heathstone.Services
{
    public class SeedService
    {
        private readonly MongoClient _client;
        public SeedService()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            var db = _client.GetDatabase("Heathstone");
            if (_client.GetDatabase("CardsCollection").ListCollections().ToList().Count == 0)
            {
                var Cardcollection = db.GetCollection<Card>("CardsCollection");
                foreach (var path in new[] { "cards.json" })
                {
                    using (var file = new StreamReader(path))
                    {
                        var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        Cardcollection.InsertMany(cards);
                    }
                }
                var Metacollection = db.GetCollection<MetaData>("MetaDataCollection");
                foreach (var path in new[] { "metadata.json" })
                {
                    using (var file = new StreamReader(path))
                    {
                        var data = JsonSerializer.Deserialize<List<MetaData>>(file.ReadToEnd(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        Metacollection.InsertMany(data);
                    }
                }
            }
        }
        public MongoClient Client
        {
            get
            {
                return _client;
            }
        }
    }
}
