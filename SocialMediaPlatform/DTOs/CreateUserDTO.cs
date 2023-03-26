using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.DTOs
{
    public class CreateUserDTO
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
