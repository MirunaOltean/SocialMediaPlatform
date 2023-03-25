
using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.DTOs
{
    public class UserDTO
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Post> Posts { get; set; } = new List<Post> { };
    }
}
