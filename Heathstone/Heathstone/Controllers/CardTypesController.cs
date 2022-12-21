using Heathstone.Models;
using Heathstone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Heathstone.Controllers
{
    [Route("types")]
    [ApiController]
    public class CardTypesController : Controller
    {
        private readonly CardsService _Service;

        public CardTypesController(CardsService service)
        {
            _Service = service;

        }




        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CardType>>> GetCardType()
        {
            return await _Service.GetCardType();
        }
    }
}
