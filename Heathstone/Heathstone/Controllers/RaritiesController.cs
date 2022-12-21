using Heathstone.Models;
using Heathstone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Heathstone.Controllers
{
    [Route("rarities")]
    [ApiController]
    public class RaritiesController : Controller
    {
        private readonly CardsService _Service;

        public RaritiesController(CardsService service)
        {
            _Service = service;

        }




        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Rarity>>> GetRarities()
        {
            return await _Service.GetRarities();
        }
    }
}
