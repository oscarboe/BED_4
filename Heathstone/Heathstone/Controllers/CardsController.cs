using Microsoft.AspNetCore.Mvc;
using Heathstone.Services;
using static Heathstone.Services.CardsService;

namespace Heathstone.Controllers
{
    [Route("cards")]
    [ApiController]
    public class CardsController : Controller
    {
        private readonly CardsService _cardsService;

        public CardsController(CardsService cardsService) =>
            _cardsService = cardsService;

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<F>>> GetCards(int id) =>
            await _cardsService.GetCards(id);
    }
}
