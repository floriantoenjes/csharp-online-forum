﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineForum.Models;
using OnlineForum.Services;

namespace OnlineForum.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        private readonly PrivateMessageService _privateMessageService;

        private readonly NotificationService _notificationService;

        public UserController(UserService userService, PrivateMessageService privateMessageService, NotificationService notificationService)
        {
            _userService = userService;
            _privateMessageService = privateMessageService;
            _notificationService = notificationService;
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
        public IActionResult SendPrivateMessage(int recipientId, PrivateMessage privateMessage)
        {
            _privateMessageService.SendPrivateMessage(this.CurrentUserId(), recipientId, privateMessage);

            _notificationService.CreateNotification(recipientId, NotificationType.PrivateMessage, privateMessage.Id);
            
            return RedirectToAction("UserDetails", new {userId = recipientId});
        }
    }
}