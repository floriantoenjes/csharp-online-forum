using Microsoft.AspNetCore.Mvc;
using OnlineForum.Services;

namespace OnlineForum.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        
        public IActionResult UserList()
        {
            ViewBag.Users = _userService.GetAllUsers();
            
            return View();
        }
    }
}