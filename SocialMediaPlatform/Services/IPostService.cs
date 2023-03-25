using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.Services
{
    public interface IPostService : ICollectionService<PostDTO>
    {
        Task<List<CommentDTO>> GetAllCommentsForPost(int postId);
    }
}
