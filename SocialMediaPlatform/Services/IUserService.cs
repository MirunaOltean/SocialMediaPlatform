using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.Services
{
    public interface IUserService : ICollectionService<UserDTO>
    {
        Task<List<CommentDTO>> GetAllCommentsForUser(int userId);
        Task<List<PostDTO>> GetAllPostsForUser(int userId);
    }
}