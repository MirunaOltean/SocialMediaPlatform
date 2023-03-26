using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.DTOs
{
    public class CommentDTO
    {
        public string Content { get; set; } = null!;
        public DateTime TimeStamp { get; set; }
        public int PostId { get; set; }
        public int AuthorId { get; set; }
    }
}
