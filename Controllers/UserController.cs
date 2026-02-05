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
            if(Username == null)
                return View(null);

            var user = await _userService.GetUserAsync(Username); // Obtener datos del usuario
            return View(user); // Retornar la vista con los datos del usuario
        }

        public async Task<IActionResult> Followers(string Username) // Accion para obtener seguidores
        {
            if(string.IsNullOrEmpty(Username))
            {
                ViewBag.Error = "Debe proporcionar un nombre de usuario";
                return View(new List<Models.GetFollowersDTO>());
            }

            var followers = await _userService.GetFollowersAsync(Username); // Obtener seguidores del usuario
            ViewBag.Username = Username; // Pasar el nombre de usuario a la vista
            return View(followers); // Retornar la vista con la lista de seguidores
        }
        public async Task<IActionResult> Following(string UserName)
        {
            if (UserName == null)
                return View(new List<Models.FollowingDTO>());

            var following = await _userService.GetFollowingsAsync(UserName);
            return View(following);
        }
    }
}
