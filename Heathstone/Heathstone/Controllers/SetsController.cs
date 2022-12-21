using Heathstone.Models;
using Microsoft.AspNetCore.Mvc;
using Heathstone.Services;

namespace Heathstone.Controllers
{
    [Route("sets")]
    [ApiController]
    public class SetsController : Controller
    {
        private readonly SetsService _Service;

        public SetsController(SetsService service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Set>>> GetSets() =>
            await _Service.GetSets();
    }
}