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
        private readonly ILogger _logger;

        public CardsController(CardsService cardsService, ILogger<CardsController> log) =>
            (_cardsService, _logger) = (cardsService, log);


        [HttpGet]
        public async Task<ActionResult<IEnumerable<F>>> GetCards(int? page, int? setid, string? artist, int? rarityid, int? classid)
        {
            _logger.LogInformation("GetCards called");
            return await _cardsService.GetCards(page, setid, artist, rarityid, classid);
        }
    }
}
