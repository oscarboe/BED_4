using Heathstone.Models;
using Heathstone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Heathstone.Controllers
{
    [Route("rarities")]
    [ApiController]
    public class RaritiesController : Controller
    {
        private readonly RaritiesService _Service;

        public RaritiesController(RaritiesService service)
        {
            _Service = service;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Rarity>>> GetRarities() =>
            await _Service.GetRarities();
    }
}
