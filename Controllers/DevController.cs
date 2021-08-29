using Microsoft.AspNetCore.Mvc;

namespace T4i_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Vinicius");
        }
    }
}