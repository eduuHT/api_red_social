using api_red_social.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_red_social.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService; // Inyeccion de dependencia del UserService
        }
        public async Task<IActionResult> Index(string Username) // Accion para manejar las solicitudes a /User/Index
        {
            var user = await _userService.GetUserAsync(Username); // Obtener datos del usuario
            return View(user); // Retornar la vista con los datos del usuario
        }
    }
}
