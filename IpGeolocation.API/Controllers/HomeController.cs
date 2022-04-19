using Microsoft.AspNetCore.Mvc;

namespace IpGeolocation.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("IpGeolocation API is running.");
        }
    }
}
