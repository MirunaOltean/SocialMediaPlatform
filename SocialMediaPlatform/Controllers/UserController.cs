using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatform.DTOs;
using SocialMediaPlatform.Services;


namespace SocialMediaPlatform.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _userService.Get(id));
        }

        [HttpGet("/comments/{id}")]
        public async Task<IActionResult> GetCommentsByUserId(int id)
        {
            return Ok(await _userService.GetAllCommentsForUser(id));
        }

        [HttpGet("/posts/{id}")]
        public async Task<IActionResult> GetPostsByUserId(int id)
        {
            return Ok(await _userService.GetAllPostsForUser(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
        {
            await _userService.Create(user);
            return Ok(await _userService.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO user)
        {
            await _userService.Update(id, user);
            return Ok(await _userService.Get(id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.Delete(id);
            return Ok(await _userService.GetAll());
        }
    }
}
