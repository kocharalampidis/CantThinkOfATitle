using CantThinkOfATitle.Data;
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
        private readonly DataContext _dbContext;


        public UserController(IUserService userService, DataContext dataContext)
        {
            _userService = userService;
            _dbContext = dataContext;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("GetUsers2")]
        public async Task<ActionResult<List<User>>> GetAllUsers2()
        {
            var test = await _dbContext.Users.ToListAsync();
            return Ok(test);
        }

        [HttpGet("GetSingleUserById")]
        public async Task<ActionResult<User>> GetSingleUserById(int id)
        {

            return Ok(_userService.GetById(id));
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> PostUser(User user)
        {

            return Ok(_userService.AddUser(user));

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