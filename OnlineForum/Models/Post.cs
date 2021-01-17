﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public User Creator { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
