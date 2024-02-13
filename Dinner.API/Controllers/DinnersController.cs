using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Tutorial.Controllers
{
    [Route("[controller]")]
    public class DinnersController : ControllerBase
    {
        public DinnersController()
        {
            
        }

        [HttpGet]
        public IActionResult ListDinners()
        {
            return Ok(new List<string>());
        }
    }
}
