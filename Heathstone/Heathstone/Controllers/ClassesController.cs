using Heathstone.Models;
using Heathstone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Heathstone.Controllers
{
    [Route("classes")]
    [ApiController]
    public class ClassesController : Controller
    {
        private readonly ClassesService _Service;
        private readonly ILogger _logger;

        public ClassesController(ClassesService service, ILogger<ClassesController> logger)
        {
            _Service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            _logger.LogInformation("GetClasses called");
            return await _Service.GetClasses();
        }
    }
}
