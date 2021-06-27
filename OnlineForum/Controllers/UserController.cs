using System.Collections.Generic;
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
            // ViewBag.PrivateMessages = _privateMessageService.GetPrivateMessagesByUserId(this.CurrentUserId());
            ViewBag.PrivateMessages = _privateMessageService.GetConversation(this.CurrentUserId(), userId);

            return View();
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult SendPrivateMessage(int recipientId, PrivateMessage privateMessage)
        {
            _privateMessageService.SendPrivateMessage(this.CurrentUserId(), recipientId, privateMessage);

            var receivers = new List<User>();
            receivers.Add(_userService.GetUser(recipientId));
            
            _notificationService.CreateNotification(receivers, NotificationType.PrivateMessage, privateMessage.Id);
            
            return RedirectToAction("UserDetails", new {userId = recipientId});
        }
    }
}