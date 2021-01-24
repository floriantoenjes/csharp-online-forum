using System.Linq;
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

        private readonly PrivateMessageService _privateMessageService;

        public ControlPanelController(ThreadService threadService, UserService userService, PrivateMessageService privateMessageService)
        {
            _privateMessageService = privateMessageService;
            _threadService = threadService;
            _userService = userService;
        }


        public IActionResult ControlPanel()
        {
            ViewBag.User = _userService.GetUser(this.CurrentUserId());
            ViewBag.PrivateMessages = _privateMessageService.GetPrivateMessagesByUserId(this.CurrentUserId())
                .Where(pm => pm.RecipientId == this.CurrentUserId());

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