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

        public CardTypesController(CardTypesService service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardType>>> GetCardType() =>
            await _Service.GetCardType();
    }
}
