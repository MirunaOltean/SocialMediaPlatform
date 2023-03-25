using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Models;


namespace SocialMediaPlatform.Mappings
{
    public static class PostMappings
    {
        public static List<PostDTO> ToPostsDTO(this List<Post> posts)
        {
            return posts.Select(e => e.ToPostDTO()).ToList();
        }

        public static PostDTO ToPostDTO(this Post post)
        {
            if (post == null) return new PostDTO();

            return new PostDTO
            {
                TimeStamp = post.TimeStamp,
                Content = post.Content,
                Author = post.Author
            };
        }
    }
}
