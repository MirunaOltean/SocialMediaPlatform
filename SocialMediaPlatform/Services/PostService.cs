using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Mappings;
using SocialMediaPlatform.Models;
using SocialMediaPlatform.Repositories;

namespace SocialMediaPlatform.Services
{
    public class PostService : IPostService
    {
        private readonly PostRepository _postRepository;

        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        public async Task<bool> Create(PostDTO model)
        {
            Post post = new()
            {
                Content = model.Content,
                AuthorId = model.Author.Id,
                TimeStamp = model.TimeStamp
            };
            await _postRepository.AddPost(post);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await _postRepository.GetPostById(id);

            if (post == null)
            {
                return false;
            }
            await _postRepository.DeletePost(post);
            return true;
        }

        public async Task<PostDTO> Get(int id)
        {
            return (await _postRepository.GetPostById(id)).ToPostDTO();
        }

        public async Task<List<PostDTO>> GetAll()
        {
            return (await _postRepository.GetAllPosts()).ToPostsDTO();
        }

        public async Task<List<CommentDTO>> GetAllCommentsForPost(int postId)
        {
            return (await _postRepository.GetAllCommentsForPost(postId)).ToCommentsDTO();
        }

        public async Task<bool> Update(int id, PostDTO model)
        {
            var post = await _postRepository.GetPostById(id);

            if (post == null)
            {
                return false;
            }

            post.Content = model.Content;
            await _postRepository.UpdatePost(post);

            return true;
        }
    }
}
