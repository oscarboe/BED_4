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

public class RaritiesService
{
    private readonly IMongoCollection<Rarity> _raritiesCollection;

    public RaritiesService(
        IOptions<HearthstoneDBSettings> mongoDbSettings)
    {
        
        var mongoClient = new MongoClient(
            mongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        _raritiesCollection = mongoDatabase.GetCollection<Rarity>(
            mongoDbSettings.Value.RaritiesCollectionName);
    }

    public async Task<ActionResult<IEnumerable<Rarity>>> GetRarities() => 
        await _raritiesCollection.AsQueryable().ToListAsync();
}
