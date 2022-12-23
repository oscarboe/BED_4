using Heathstone.Models;
using Heathstone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Heathstone.Controllers
{
    [Route("types")]
    [ApiController]
    public class CardTypesController : Controller
    {
        private readonly CardTypesService _Service;
        private readonly ILogger _logger;

        public CardTypesController(CardTypesService service, ILogger<CardTypesController> logger)
        {
            _Service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardType>>> GetCardType()
        {
            _logger.LogInformation("GetCardType called");
            return await _Service.GetCardType();

        }
    }
}
