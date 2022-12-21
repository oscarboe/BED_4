using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heathstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Heathstone.Services;

public class CardsService
    {
    private readonly IMongoCollection<Card> _cardsCollection;
    private readonly IMongoCollection<CardType> _cardTypesCollection;
    private readonly IMongoCollection<SeedService> _classesCollection;
    private readonly IMongoCollection<Rarity> _raritiesCollection;
    private readonly IMongoCollection<Set> _setsCollection;

    public CardsService(
        IOptions<HearthstoneDBSettings> mongoDbSettings)
    {
        
        var mongoClient = new MongoClient(
            mongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        _cardsCollection = mongoDatabase.GetCollection<Card>(
            mongoDbSettings.Value.CardsCollectionName);

     /*   _cardTypesCollection = mongoDatabase.GetCollection<CardType>(
            mongoDbSettings.Value.MetaDataCollection.Select(Array a => a).Where(x => x == "CardTypes").First());

        _classesCollection = mongoDatabase.GetCollection<SeedService>(
            mongoDbSettings.Value.MetaDataCollection.Select().Where(x => x == "Classes").First());

        _raritiesCollection = mongoDatabase.GetCollection<Rarity>(
            mongoDbSettings.Value.MetaDataCollection.Select().Where(x => x == "Rarities").First());

        _setsCollection = mongoDatabase.GetCollection<Set>(
            mongoDbSettings.Value.MetaDataCollection.Select().Where(x => x == "Sets").First());*/
    }

    public class F
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Class { get; set; }
        public String Type { get; set; }
        public String Set { get; set; }
        public String? SpellSchool { get; set; }
        public String Rarity { get; set; }
        public int? Health { get; set; }
        public int? Attack { get; set; }
        public int ManaCost { get; set; }
        public String Artist { get; set; }
        public String Text { get; set; }
        public String FlavorText { get; set; }
    }

//    public async Task<ActionResult<IEnumerable<F>>> GetCards(int? page/*, string? artist, int? setId, int? rarityId, int? classId*/)
//    {
//        var cards = await _cardsCollection.AsQueryable().ToListAsync();

//        _cardsCollection.Aggregate();
//        return result.ToList();
//    }
}
