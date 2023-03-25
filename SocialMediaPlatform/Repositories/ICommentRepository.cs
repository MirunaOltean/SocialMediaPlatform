using SocialMediaPlatform.Models;


namespace SocialMediaPlatform.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComments();
        Task<Comment> GetCommentById(int id);
        Task<bool> AddComment(Comment comment);
        Task<bool> UpdateComment(Comment comment);
        Task<bool> DeleteComment(Comment comment);
    }
}
