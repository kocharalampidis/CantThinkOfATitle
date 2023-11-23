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

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpGet("GetSingleUser/{email}")]
        //public async Task<ActionResult<User>> GetSingleUser(string email)
        //{
        //    var response = await _postService.GetUserByEmail(email);
        //    if (!response.Success)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(response);
        //}

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPost("AddUser")]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    var response = await _postService.AddUser(user);
        //    if (!response.Success)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(response);

        //}

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPut("UpdateUser/{email}")]
        //public async Task<ActionResult<User>> UpdateUser(UserDTO user, string email)
        //{
        //    var response = await _postService.UpdateUser(user, email);
        //    if (!response.Success)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(response);

        //}

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpDelete("DeleteUser/{email}")]

        //public async Task<ActionResult<User>> DeleteUser(string email)
        //{
        //    var response = await _postService.DeleteUser(email);
        //    if (!response.Success)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(response);

        //}
    }
}

//// GET: api/<ValuesController>
//[HttpGet]
//public IEnumerable<string> Get()
//{
//    return new string[] { "value1", "value2" };
//}

//// GET api/<ValuesController>/5
//[HttpGet("{id}")]
//public string Get(int id)
//{
//    return "value";
//}

//// POST api/<ValuesController>
//[HttpPost]
//public void Post([FromBody] string value)
//{
//}

//// PUT api/<ValuesController>/5
//[HttpPut("{id}")]
//public void Put(int id, [FromBody] string value)
//{
//}

//// DELETE api/<ValuesController>/5
//[HttpDelete("{id}")]
//public void Delete(int id)
//{
//}