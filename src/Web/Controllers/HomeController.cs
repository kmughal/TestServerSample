using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
    }
}
