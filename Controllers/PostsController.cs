using CantThinkOfATitle.Data;
using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;
using CantThinkOfATitle.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CantThinkOfATitle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService= postService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetPosts")]
        public async Task<ActionResult<List<PostResponseDTO>>> GetAllPosts()
        {
            var response = await _postService.GetAllPosts();
            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpGet("GetPostPerUser/{id}")]
        public async Task<ActionResult<List<PostResponseDTO>>> GetUserPosts(int id)
        {
            var response = await _postService.GetUserPosts(id);
            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetPostsById/{id}")]
        public async Task<ActionResult<List<PostResponseDTO>>> GetPostsById(int id)
        {
            var response = await _postService.GetPostsById(id);
            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}
