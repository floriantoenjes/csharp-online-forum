using System;
using System.Collections.Generic;
using OnlineForum.Models;

namespace OnlineForum.ViewModels
{
    public class ControlPanelViewModel
    {
        public User User { get; set; }
        
        public IDictionary<string, List<PrivateMessage>> Conversations { get; set; }
    }
}