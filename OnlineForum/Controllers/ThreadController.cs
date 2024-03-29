﻿using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineForum.Models;
using OnlineForum.Services;

namespace OnlineForum.Controllers
{
    public class ThreadController : Controller
    {
        private readonly ThreadService _threadService;

        private readonly PostService _postService;
        

        private readonly UserService _userService;

        private readonly NotificationService _notificationService;

        public ThreadController(ThreadService threadService, PostService postService, UserService userService, NotificationService notificationService)
        
        {
            _threadService = threadService;
            _postService = postService;
            _userService = userService;
            _notificationService = notificationService;
        }
        
        public IActionResult Thread(int threadId, int page = 0, int limit = 10)
        {
            var thread = _threadService.GetThread(threadId);
            ViewBag.Thread = thread;
            ViewBag.posts = _postService.GetPostsByThreadId(threadId, page * limit, limit);
            ViewBag.totalPostCount = _postService.GetPostsBbyThreadIdTotalCount(threadId);
            ViewBag.limit = limit;
            ViewBag.currentPage = page;
            var currentUser = _userService.GetUser(this.CurrentUserId()); 
            ViewBag.CurrentUser = currentUser;

            return View();
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult CreatePost(int threadId, Post post)
        {
            if (ModelState.IsValid)
            {
                _threadService.CreatePost(threadId, post, this.CurrentUserId());
                var subscribers = _threadService.GetThread(threadId).Subscribers
                    .Where(subscriber => subscriber.Id != this.CurrentUserId()).ToList();
                
                _notificationService.CreateNotification(subscribers, NotificationType.NewPost, threadId);
            }

            return RedirectToAction("Thread", new {threadId});
            
        }

        [HttpPost]
        [Authorize]
        public IActionResult SubscribeToThread(int threadId)
        {
            _threadService.SubscribeToThread(threadId, this.CurrentUserId());

            return Ok();
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult UnsubscribeFromThread(int threadId)
        {
            _threadService.UnsubscribeFromThread(threadId, this.CurrentUserId());

            return Ok();
        }
    }
}