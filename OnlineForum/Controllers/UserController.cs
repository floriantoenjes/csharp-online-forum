using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineForum.Models;
using OnlineForum.Services;

namespace OnlineForum.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        private readonly PrivateMessageService _privateMessageService;

        public UserController(UserService userService, PrivateMessageService privateMessageService)
        {
            _userService = userService;
            _privateMessageService = privateMessageService;
        }

        public IActionResult UserList()
        {
            ViewBag.Users = _userService.GetAllUsers();
            
            return View();
        }
        
        [Authorize]
        public IActionResult UserDetails(int userId)
        {
            ViewBag.User = _userService.GetUser(userId);

            return View();
        }
        
        [HttpPost]
        [Authorize]
        public void SendPrivateMessage(int recipientId, PrivateMessage privateMessage)
        {
            _privateMessageService.sendPrivateMessage(recipientId, privateMessage);
        }
    }
}