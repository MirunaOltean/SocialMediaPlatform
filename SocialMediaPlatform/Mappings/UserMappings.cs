using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Models;


namespace SocialMediaPlatform.Mappings
{
    public static class UserMappings
    {
        public static List<UserDTO> ToUsersDTO(this List<User> users)
        {
            return users.Select(e => e.ToUserDTO()).ToList();
        }

        public static UserDTO ToUserDTO(this User user)
        {
            if (user == null) return new UserDTO();

            return new UserDTO
            {
                FullName = user.FirstName + " " + user.LastName,
                Comments = user.Comments.ToList(),
                Posts = user.Posts.ToList()
            };
        }
    }
}
