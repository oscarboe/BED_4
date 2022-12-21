using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heathstone.Services
{
    using Heathstone.Models;
    public class CardsService
    {
        private readonly ILogger<CardService> _logger;
        private readonly IMongoCollection<Card> _collection;

        public CardService(ILogger<CardService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("mtg").GetCollection<Card>("cards");
            _logger = logger;
        }
    }
}
