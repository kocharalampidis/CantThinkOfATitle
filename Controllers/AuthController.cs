using CantThinkOfATitle.Data;
using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.DTOs.Auth;
using CantThinkOfATitle.Models;
using CantThinkOfATitle.Responses.Auth;
using CantThinkOfATitle.Services.Interfaces;
using CantThinkOfATitle.Services.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CantThinkOfATitle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;

        public AuthController
            (
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IAuthenticationService authenticationService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Register")]
        public async Task<ActionResult<RegisterUserResponse<RegisterUserDTO>>> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            var response = await _authenticationService.Registration(registerUserDTO);

            if (!response.Success)
            {
                response.Success = false;
                response.Message = "Failed at controller";
            }

            return response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<LoginResponse<LoginDTO>>> Login([FromBody] LoginDTO login)
        {
            var response = await _authenticationService.Login(login);
            if (!response.Success)
            {
                return Unauthorized();
            }

            return response;
        }

        
    }
}
