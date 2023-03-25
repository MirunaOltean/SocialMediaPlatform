﻿using SocialMediaPlatform.Models;


namespace SocialMediaPlatform.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateOnly TimeStamp { get; set; }
        public User Author { get; set; } = new User();

    }
}
