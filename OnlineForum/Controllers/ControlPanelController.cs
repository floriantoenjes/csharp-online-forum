using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineForum.Services;

namespace OnlineForum.Controllers
{
    [Authorize]
    public class ControlPanelController : Controller
    {
        private readonly UserService _userService;

        public ControlPanelController(UserService userService)
        {
            _userService = userService;
        }


        public IActionResult ControlPanel()
        {
            ViewBag.User = _userService.GetUser(this.CurrentUserId());

            return View();
        }
    }
}