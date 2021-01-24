using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnlineForum.Models;
using OnlineForum.Services;
using OnlineForum.SignalR;

namespace OnlineForum.Controllers
{
    public class ThreadController : Controller
    {
        private readonly ThreadService _threadService;

        private readonly UserService _userService;

        private readonly IHubContext<NotificationHub> _hubContext;

        public ThreadController(ThreadService threadService, UserService userService, IHubContext<NotificationHub> hubContext)
        {
            _threadService = threadService;
            _userService = userService;
            _hubContext = hubContext;
        }
        
        public IActionResult Thread(int threadId)
        {
            var thread = _threadService.GetThread(threadId);
            ViewBag.Thread = thread;
            var currentUser = _userService.GetUser(this.CurrentUserId()); 
            ViewBag.CurrentUser = currentUser;

            return View();
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Thread(int threadId, Post post)
        {
            if (ModelState.IsValid)
            {
                _threadService.CreatePost(threadId, post, this.CurrentUserId());
                _hubContext.Clients.All.SendAsync("ReceiveMessage", "Ja man!");
            }

            return RedirectToAction("Thread", new {threadId});
            
        }

        [HttpPost]
        [Authorize]
        public IActionResult SubscribeToThread(int threadId)
        {
            _threadService.SubscribeToThread(threadId, this.CurrentUserId());

            return RedirectToAction("Thread", new {threadId});
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult UnsubscribeFromThread(int threadId)
        {
            _threadService.UnsubscribeFromThread(threadId, this.CurrentUserId());
            
            return RedirectToAction("Thread", new {threadId});
        }
    }
}