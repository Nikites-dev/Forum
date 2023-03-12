using System;

namespace Forum.Models
{
    public class Comment
    {
        public int UserId { get; set; }
        public String Text { get; set; }
        public int Rating { get; set; }
    }
}

