using SocialMediaPlatform.Models;


namespace SocialMediaPlatform.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<List<Post>> GetAllPostsForUser(int userId);
        Task<List<Comment>> GetAllCommentsForUser(int userId);
        Task<User> GetUserById(int id);
        Task<bool> AddUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
    }
}
