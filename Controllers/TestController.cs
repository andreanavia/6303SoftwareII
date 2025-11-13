using Microsoft.AspNetCore.Mvc;

namespace MovieReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("¡La API de películas funciona correctamente!");
        }
    }
}
