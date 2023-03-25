using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Mappings;
using SocialMediaPlatform.Models;
using SocialMediaPlatform.Repositories;

namespace SocialMediaPlatform.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<CommentDTO>> GetAll()
        {
            return (await _commentRepository.GetAllComments()).ToCommentsDTO();
        }

        public async Task<CommentDTO> Get(int id)
        {
            return (await _commentRepository.GetCommentById(id)).ToCommentDTO();
        }

        public async Task<bool> Create(CommentDTO model)
        {
            Comment comment = new()
            {
                Content = model.Content,
                AuthorId = model.Author.Id,
                PostId = model.Post.Id,
                TimeStamp = model.TimeStamp
            };
            await _commentRepository.AddComment(comment);
            return true;
        }

        public async Task<bool> Update(int id, CommentDTO model)
        {
            var comment = await _commentRepository.GetCommentById(id);

            if (comment == null)
            {
                return false;
            }

            comment.Content = model.Content;
            await _commentRepository.UpdateComment(comment);

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _commentRepository.GetCommentById(id);

            if(result == null)
            {
                return false;
            }
            await _commentRepository.DeleteComment(result);
            return true;
        }
    }
}
