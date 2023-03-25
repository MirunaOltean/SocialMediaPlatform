using Microsoft.EntityFrameworkCore;
using SocialMediaPlatform.DBContext;
using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.Repositories
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(SocialMediaPlatformContext context) : base(context) {  }

        public async Task<bool> AddPost(Post post)
        {
            await _socialMediaPlatformContext.Posts.AddAsync(post);
            await _socialMediaPlatformContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePost(Post post)
        {
            _socialMediaPlatformContext.Posts.Remove(post);
            await _socialMediaPlatformContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _socialMediaPlatformContext.Posts.ToListAsync();
        }

        public async Task<List<Comment>> GetAllCommentsForPost(int postId)
        {
            return await _socialMediaPlatformContext.Comments.Where(comment => comment.PostId == postId).ToListAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
           return await _socialMediaPlatformContext.Posts.FirstOrDefaultAsync(post => post.Id == id);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            _socialMediaPlatformContext.Posts.Update(post);
            await _socialMediaPlatformContext.SaveChangesAsync();
            return true;
        }
    }
}
