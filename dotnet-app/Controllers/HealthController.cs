using Microsoft.AspNetCore.Mvc;

namespace RealtimeChat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new { status = "ok", timestamp = System.DateTime.UtcNow });
    }
}
