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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsers()
        {
            var response = await _userService.GetAllUsers();
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
        [HttpGet("GetSingleUser/{email}")]
        public async Task<ActionResult<User>> GetSingleUser(string email)
        {
            var response = await _userService.GetUserByEmail(email);
            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var response = await _userService.AddUser(user);
            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("UpdateUser/{email}")]
        public async Task<ActionResult<User>> UpdateUser(UserDTO user, string email)
        {
            var response = await _userService.UpdateUser(user, email);
            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("DeleteUser/{email}")]

        public async Task<ActionResult<User>> DeleteUser(string email)
        {
            var response = await _userService.DeleteUser(email);
            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);

        }
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