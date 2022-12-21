using MongoDB.Driver;
using System.Text.Json;
using Heathstone.Models;

namespace Heathstone.Services;

public class MongoService
{

    private readonly MongoClient _client;
    public MongoService()
    {
       // _client = new MongoClient("mongodb://localhost:5000");
        var db = _client.GetDatabase("mtg");
        if (_client.GetDatabase("heathstone").ListCollections().ToList().Count == 0)
        {
            var collection = db.GetCollection<Card>("cards");
            foreach (var path in new[] { "cards.json" })
            {
                using (var file = new StreamReader(path))
                {
                    var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    collection.InsertMany(cards);
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