using SocialMediaPlatform.Models;


namespace SocialMediaPlatform.Repositories
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllPosts();
        Task<List<Comment>> GetAllCommentsForPost(int postId);
        Task<Post> GetPostById(int id);
        Task<bool> AddPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(Post post);
    }
}
