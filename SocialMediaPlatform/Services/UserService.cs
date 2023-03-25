using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Mappings;
using SocialMediaPlatform.Models;
using SocialMediaPlatform.Repositories;

namespace SocialMediaPlatform.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<bool> Create(UserDTO model)
        {
            User user = new()
            {
                FirstName = model.FullName.Split(' ').First(),
                LastName = model.FullName.Split(' ').Last(),
                Email = model.Email,
                Password = model.Password
            };
            await _userRepository.AddUser(user);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _userRepository.GetUserById(id);

            if (result == null)
            {
                return false;
            }
            await _userRepository.DeleteUser(result);
            return true;
        }

        public async Task<UserDTO> Get(int id)
        {
            return (await _userRepository.GetUserById(id)).ToUserDTO();
        }

        public async Task<List<UserDTO>> GetAll()
        {
            return (await _userRepository.GetAllUsers()).ToUsersDTO();
        }

        public async Task<List<CommentDTO>> GetAllCommentsForUser(int userId)
        {
            return (await _userRepository.GetAllCommentsForUser(userId)).ToCommentsDTO();
        }

        public async Task<List<PostDTO>> GetAllPostsForUser(int userId)
        {
            return (await _userRepository.GetAllPostsForUser(userId)).ToPostsDTO();
        }

        public async Task<bool> Update(int id, UserDTO model)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return false;
            }

            user.FirstName = model.FullName.Split(' ')[0];
            user.LastName = model.FullName.Split(' ')[1];
            user.Password = model.Password;
            user.Email = model.Email;
            await _userRepository.UpdateUser(user);

            return true;
        }
    }
}
