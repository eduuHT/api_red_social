using api_red_social.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_red_social.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
