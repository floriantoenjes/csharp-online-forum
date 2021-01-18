using Microsoft.AspNetCore.Mvc;
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
    }
}