using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineForum.Models;
using OnlineForum.Services;
using OnlineForum.ViewModels;

namespace OnlineForum.Controllers
{
    [Authorize]
    public class ControlPanelController : Controller
    {
        private readonly ThreadService _threadService;

        private readonly UserService _userService;

        private readonly PrivateMessageService _privateMessageService;
        
        private readonly NotificationService _notificationService;

        public ControlPanelController(ThreadService threadService, UserService userService, PrivateMessageService privateMessageService, NotificationService notificationService)
        {
            _threadService = threadService;
            _userService = userService;
            _privateMessageService = privateMessageService;
            _notificationService = notificationService;
        }


        public IActionResult ControlPanel()
        {
            var controlPanelViewModel = new ControlPanelViewModel();
            
            controlPanelViewModel.User = _userService.GetUser(this.CurrentUserId()); 
            controlPanelViewModel.Conversations = _privateMessageService
                .GetConversationsByUserId(this.CurrentUserId());
            
            return View(controlPanelViewModel);
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult UnsubscribeFromThread(int threadId)
        {
            _threadService.UnsubscribeFromThread(threadId, this.CurrentUserId());

            return RedirectToAction("ControlPanel");
        }

        public IActionResult GoToNotification(int notificationId)
        {
            var readNotification = _notificationService.MarkNotificationRead(notificationId);
            switch (readNotification.NotificationType)
            {
                case NotificationType.NewPost:
                    return RedirectToAction("Thread", "Thread", new {threadId = readNotification.TypeIdentifier});
                case NotificationType.PrivateMessage:
                    return RedirectToAction("ControlPanel", "ControlPanel");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [HttpPost]
        public IActionResult MarkAllNotificationsRead()
        {
            _notificationService.MarkAllNotificationsRead(this.CurrentUserId());
            return Ok();
        }
    }
}