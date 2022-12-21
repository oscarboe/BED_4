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
using static Heathstone.Services.CardsService;

namespace Heathstone.Services;

public class CardTypesService
{
    private readonly IMongoCollection<CardType> _cardTypesCollection;

    public CardTypesService(
        IOptions<HearthstoneDBSettings> mongoDbSettings)
    {
        
        var mongoClient = new MongoClient(
            mongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        _cardTypesCollection = mongoDatabase.GetCollection<CardType>(
            mongoDbSettings.Value.TypesCollectionName);
    }

    public async Task<ActionResult<IEnumerable<CardType>>> GetCardType()
    {
        return await _cardTypesCollection.AsQueryable().ToListAsync();
    }
}
