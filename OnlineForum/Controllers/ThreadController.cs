using System;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Thread(int threadId, Post post)
        {
            if (ModelState.IsValid)
            {
                _threadService.CreatePost(threadId, post, this.CurrentUserId());
            }

            return RedirectToAction("Thread", new {threadId});
            
        }

        [HttpPost]
        [Authorize]
        public IActionResult SubscribeToThread(int threadId)
        {
            _threadService.SubscribeToThread(threadId);

            return RedirectToAction("Thread", new {threadId});
        }
    }
}