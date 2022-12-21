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

public class SetsService
{
    private readonly IMongoCollection<Set> _setsCollection;

    public SetsService(
        IOptions<HearthstoneDBSettings> mongoDbSettings)
    {
        
        var mongoClient = new MongoClient(
            mongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        _setsCollection = mongoDatabase.GetCollection<Set>(
            mongoDbSettings.Value.SetsCollectionName);
    }

    public async Task<ActionResult<IEnumerable<Set>>> GetSets() =>
        await _setsCollection.AsQueryable().ToListAsync();
}
