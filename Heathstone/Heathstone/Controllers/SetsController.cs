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
        private readonly ILogger _logger;

        public SetsController(SetsService service, ILogger<SetsController> logger)
        {
            _Service = service;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Set>>> GetSets()
        {
            _logger.LogInformation("GetSets called");
            return await _Service.GetSets();
        }
    }
}