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
        private readonly ILogger _logger;
        public RaritiesController(RaritiesService service, ILogger<RaritiesController> logger)
        {
            _Service = service;
            _logger = logger;
        }
        
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Rarity>>> GetRarities()
        {
            _logger.LogInformation("GetRarities called");
            return await _Service.GetRarities();
        }
    }
}
