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

public class ClassesService
{
    private readonly IMongoCollection<Class> _classesCollection;

    public ClassesService(
        IOptions<HearthstoneDBSettings> mongoDbSettings)
    {
        
        var mongoClient = new MongoClient(
            mongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        _classesCollection = mongoDatabase.GetCollection<Class>(
            mongoDbSettings.Value.ClassesCollectionName);
    }

    public async Task<ActionResult<IEnumerable<Class>>> GetClasses() =>
        await _classesCollection.AsQueryable().ToListAsync();
}
