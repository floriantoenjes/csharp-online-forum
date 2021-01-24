using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineForum.Services;

namespace OnlineForum.Controllers
{
    [Authorize]
    public class ControlPanelController : Controller
    {
        private readonly ThreadService _threadService;

        private readonly UserService _userService;

        public ControlPanelController(ThreadService threadService, UserService userService)
        {
            _threadService = threadService;
            _userService = userService;
        }


        public IActionResult ControlPanel()
        {
            ViewBag.User = _userService.GetUser(this.CurrentUserId());

            return View();
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult UnsubscribeFromThread(int threadId)
        {
            _threadService.UnsubscribeFromThread(threadId, this.CurrentUserId());

            return RedirectToAction("ControlPanel");
        }
    }
}