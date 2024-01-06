using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers.AuthController
{
    public class AuthController : Controller
    {

        [HttpGet("Auth/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("Auth/Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
