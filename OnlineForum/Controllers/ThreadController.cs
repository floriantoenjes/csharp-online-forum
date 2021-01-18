using Microsoft.AspNetCore.Mvc;
using OnlineForum.Models;
using OnlineForum.Services;

namespace OnlineForum.Controllers
{
    public class ThreadController : Controller
    {
        private ThreadService _threadService;
        
        public ThreadController(ThreadService threadService)
        {
            _threadService = threadService;
        }
        
        public IActionResult Thread(int threadId)
        {
            var thread = _threadService.GetThread(threadId);
            ViewBag.Thread = thread;

            return View();
        }
        
        [HttpPost]
        public IActionResult Thread(int threadId, Post post)
        {
            post.CreatorId = 2; // TODO: Replace with actual user

            var thread = _threadService.GetThread(threadId);
            thread.Posts.Add(post);
            _threadService.UpdateThread(thread);

            return RedirectToAction("Thread", new {threadId});
            
        }
    }
}