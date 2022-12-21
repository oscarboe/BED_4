using Heathstone.Models;
using Microsoft.AspNetCore.Mvc;
using Heathstone.Services;
using static Heathstone.Services.CardsService;

namespace Heathstone.Controllers
{
    [Route("sets")]
    [ApiController]
    public class SetsController : Controller
    {
        private readonly CardsService _Service;

        public SetsController(CardsService service)
        {
            _Service = service;

        }




        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Set>>> GetSets()
        {
            return await _Service.GetSets();
        }
    }
}