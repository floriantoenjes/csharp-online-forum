using System.Collections.Generic;
using OnlineForum.Models;

namespace OnlineForum.ViewModels
{
    public class BoardDetailViewModel
    {
        public Board Board { get; set; }
        
        public Thread Thread { get; set; }
        
        public Post Post { get; set; }
    }
}