using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Services;


namespace SocialMediaPlatform.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllPosts()
        {
            return Ok(await _postService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            return Ok(await _postService.Get(id));
        }

        [HttpGet("/comments/{id}")]
        public async Task<IActionResult> GetCommentsByPostId(int id)
        {
            return Ok(await _postService.GetAllCommentsForPost(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostDTO post)
        {
            await _postService.Create(post);
            return Ok(await _postService.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostDTO post)
        {
            await _postService.Update(id, post);
            return Ok(await _postService.Get(id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.Delete(id);
            return Ok(await _postService.GetAll());
        }
    }
}
