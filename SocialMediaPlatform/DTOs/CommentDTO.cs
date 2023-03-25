using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateOnly TimeStamp { get; set; }
        public Post Post { get; set; } = new Post();
        public User Author { get; set; } = new User();
    }
}
