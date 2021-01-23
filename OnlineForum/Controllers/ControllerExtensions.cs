using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace OnlineForum.Controllers
{
    public static class ControllerExtensions
    {
        public static int CurrentUserId(this Controller controller)
        {
            var userIdStr = controller.User.FindFirst(ClaimTypes.NameIdentifier);
            return Convert.ToInt32(userIdStr.Value);
        }
            
    }
}