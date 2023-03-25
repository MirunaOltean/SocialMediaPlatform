using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SocialMediaPlatform.DBContext;
using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(SocialMediaPlatformContext context) : base(context) {  }

        public async Task<bool> AddUser(User user)
        {
            await _socialMediaPlatformContext.Users.AddAsync(user);
            await _socialMediaPlatformContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(User user)
        {
            _socialMediaPlatformContext.Users.Remove(user);
            await _socialMediaPlatformContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comment>> GetAllCommentsForUser(int userId)
        {
            return await _socialMediaPlatformContext.Comments.Where(comment => comment.AuthorId == userId).ToListAsync();
        }

        public async Task<List<Post>> GetAllPostsForUser(int userId)
        {
            return await _socialMediaPlatformContext.Posts.Where(post => post.AuthorId == userId).ToListAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _socialMediaPlatformContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _socialMediaPlatformContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<bool> UpdateUser(User user)
        {
            _socialMediaPlatformContext.Users.Update(user);
            await _socialMediaPlatformContext.SaveChangesAsync();
            return true;
        }
    }
}
