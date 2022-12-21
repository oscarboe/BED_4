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

        public ClassesController(ClassesService service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses() =>
            await _Service.GetClasses();
    }
}
