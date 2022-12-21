using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Heathstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Heathstone.Services;

public class CardsService
    {
    private readonly IMongoCollection<Card> _cardsCollection;
    private readonly IMongoCollection<JsonObject> _cardTypesCollection;
    //private readonly IMongoCollection<Class> _classesCollection;
    //private readonly IMongoCollection<Rarity> _raritiesCollection;
    //private readonly IMongoCollection<Set> _setsCollection;

    public CardsService(
        IOptions<HearthstoneDBSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(
            mongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        _cardsCollection = mongoDatabase.GetCollection<Card>(
            mongoDbSettings.Value.CardsCollectionName);

        _cardTypesCollection = mongoDatabase.GetCollection<JsonObject>(
            mongoDbSettings.Value.MetaDataCollection);

        //_classesCollection = mongoDatabase.GetCollection<Class>(
        //    mongoDbSettings.Value.FacilitiesCollectionName);

        //_raritiesCollection = mongoDatabase.GetCollection<Rarity>(
        //    mongoDbSettings.Value.FacilitiesCollectionName);

        //_setsCollection = mongoDatabase.GetCollection<Set>(
        //    mongoDbSettings.Value.FacilitiesCollectionName);
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

    public async Task<ActionResult<IEnumerable<F>>> GetCards(int id)
    {
        //IMongoQueryable<F> stuff = from f in _facilitiesCollection.AsQueryable()
        //                           orderby f.kind
        //                           select new F
        //                           {
        //                               name = f.facilityName,
        //                               address = f.coordinates,
        //                           };
        //return await stuff.ToListAsync();

        var stuff = await _cardsCollection
                        .Find(new BsonDocument())
                        .Skip((id - 1) * 100)
                        .Limit(100)
                        .ForEachAsync(f => 
                            new F 
                            { 
                                Id = f.Id, 
                                Name = f.Name, 
                                Class = 
                            });
    }
}
