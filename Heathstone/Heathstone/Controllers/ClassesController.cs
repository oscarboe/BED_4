using Heathstone.Models;
using Heathstone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Heathstone.Controllers
{
    [Route("classes")]
    [ApiController]
    public class ClassesController : Controller
    {
        private readonly CardsService _Service;

        public ClassesController(CardsService service)
        {
            _Service = service;

        }




        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            return await _Service.GetClasses();
        }
    }
}
