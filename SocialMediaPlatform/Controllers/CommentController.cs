using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Services;


namespace SocialMediaPlatform.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllComments()
        {
            return Ok(await _commentService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCommentById(int id)
        {
            var result = await _commentService.Get(id);

            if (result == null)
            {
                return BadRequest("Comment not found");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddComment([FromBody] CommentDTO comment)
        {
            await _commentService.Create(comment);
            return Ok(comment);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateComment(int id, [FromBody] CommentDTO comment)
        {
            await _commentService.Update(id, comment);
            return Ok(await _commentService.Get(id));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteComment(int commentId)
        {
            await _commentService.Delete(commentId);
            return Ok("Comment deleted");
        }
    }
}
