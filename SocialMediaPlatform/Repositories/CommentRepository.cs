using Microsoft.EntityFrameworkCore;
using SocialMediaPlatform.DBContext;
using SocialMediaPlatform.Models;


namespace SocialMediaPlatform.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(SocialMediaPlatformContext context) : base(context) { }

        public async Task<bool> AddComment(Comment comment)
        {
            await _socialMediaPlatformContext.Comments.AddAsync(comment);
            await _socialMediaPlatformContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteComment(Comment comment)
        {
            _socialMediaPlatformContext.Comments.Remove(comment);
            await _socialMediaPlatformContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _socialMediaPlatformContext.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _socialMediaPlatformContext.Comments.FirstOrDefaultAsync(comment => comment.Id == id);
        }

        public async Task<bool> UpdateComment(Comment comment)
        {
            _socialMediaPlatformContext.Comments.Update(comment);
            await _socialMediaPlatformContext.SaveChangesAsync();
            return true;
        }
    }
}
