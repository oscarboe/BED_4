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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<F>>> GetCards(int? page, int? setid, string? artist, int? rarityid, int? classid) =>
            await _cardsService.GetCards(page, setid, artist, rarityid, classid);
    }
}
