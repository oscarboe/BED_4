﻿using System;
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

public class CardsService
    {
    private readonly IMongoCollection<Card> _cardsCollection;
    private readonly IMongoCollection<CardType> _cardTypesCollection;
    private readonly IMongoCollection<Class> _classesCollection;
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

        _cardTypesCollection = mongoDatabase.GetCollection<CardType>(
            mongoDbSettings.Value.TypesCollectionName);

        _classesCollection = mongoDatabase.GetCollection<Class>(
            mongoDbSettings.Value.ClassesCollectionName);

        _raritiesCollection = mongoDatabase.GetCollection<Rarity>(
            mongoDbSettings.Value.RaritiesCollectionName);

        _setsCollection = mongoDatabase.GetCollection<Set>(
            mongoDbSettings.Value.SetsCollectionName);
    }

    public class F
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Class { get; set; }
        public String Type { get; set; }
        public String Set { get; set; }
        public int? SpellSchoolId { get; set; }
        public String Rarity { get; set; }
        public int? Health { get; set; }
        public int? Attack { get; set; }
        public int ManaCost { get; set; }
        public String Artist { get; set; }
        public String Text { get; set; }
        public String FlavorText { get; set; }
    }

    public async Task<ActionResult<IEnumerable<F>>> GetCards(int? page, int? setid, string? artist, int? rarityid, int? classid)
    {
        List<F> stuff = new();
        int i = 0;
        foreach(Card card in _cardsCollection.AsQueryable())
        {
            i++;
            if (i > (page != null ? (page - 1) * 100 : 0) && i <= (page != null ? page * 100 : 4100) && 
                    (setid != null ? setid : card.cardSetId) == card.cardSetId &&
                    (artist != null ? artist : card.artistName) == card.artistName &&
                    (rarityid != null ? rarityid : card.RarityId) == card.RarityId &&
                    (classid != null ? classid : card.ClassId) == card.ClassId)
            {
                stuff.Add(new F
                {
                    Id = card.Id,
                    Name = card.Name,
                    Class = (from c in _classesCollection.AsQueryable()
                             where c.Id == card.ClassId
                             select c.Name).FirstOrDefault(),
                    Type = (from t in _cardTypesCollection.AsQueryable()
                            where t.Id == card.cardTypeId
                            select t.Name).FirstOrDefault(),
                    Set = (from s in _setsCollection.AsQueryable()
                           where s.Id == card.cardSetId
                           select s.Name).FirstOrDefault(),
                    SpellSchoolId = card.SpellSchoolId,
                    Rarity = (from r in _raritiesCollection.AsQueryable()
                              where r.Id == card.RarityId
                              select r.Name).FirstOrDefault(),
                    Health = card.Health,
                    Attack = card.Attack,
                    ManaCost = card.ManaCost,
                    Artist = card.artistName,
                    Text = card.Text,
                    FlavorText = card.FlavorText,
                });
                }
        }

        return stuff;
    }
}
