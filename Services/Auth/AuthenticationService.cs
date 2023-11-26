﻿using System.Security.Claims;
using CantThinkOfATitle.Services.Interfaces.Auth;
using CantThinkOfATitle.Responses.Auth;
using CantThinkOfATitle.DTOs.Auth;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Azure.Core;

namespace CantThinkOfATitle.Services.Auth
{
    public class AuthenticationService : IAuthenticationService

    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService
            (
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }



        public async Task<RegisterUserResponse<RegisterUserDTO>> Registration(RegisterUserDTO registerUserDTO)
        {
            var response = new RegisterUserResponse<RegisterUserDTO>();
            var userExists = await _userManager.FindByEmailAsync(registerUserDTO.Email);

            if(userExists != null)
            {
                response.Success = false;
                response.Message = "User Already Exists";

                return response;
            }

            IdentityUser newUser = new IdentityUser()
            {
                Email = registerUserDTO.Email,
                UserName = registerUserDTO.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var userCreated = await _userManager.CreateAsync(newUser, registerUserDTO.Password);
            if (!userCreated.Succeeded)
            {
                response.Success = false;
                response.Message = userCreated.Errors.ToString();

            }

            response.Data = registerUserDTO;
            response.Success = true;
            response.Message = "user created";

            return response;
        }

        #region Login/Logout

        public async Task<LoginResponse<LoginDTO>> Login(LoginDTO loginUser)
        {
            var response = new LoginResponse<LoginDTO>();

            var authUser = await _userManager.FindByNameAsync(loginUser.UserName);
            
            if (authUser != null && await _userManager.CheckPasswordAsync(authUser, loginUser.Password))
            {
                //var test = await _userManager
                //    .CheckPasswordAsync(authUser, loginUser.Password);

                //var userRoles = await _userManager.GetRolesAsync(authUser);

                var jwt = CreateToken(authUser);

                response.Success = true;
                response.Token = jwt;

                return response;
                
            }

            response.Success = false;
            return response;
        }


        public Task<LoginResponse<LoginDTO>> LoginAdmin(LoginDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<string> Logout()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Password

        public Task<string> ForgotPassword()
        {
            throw new NotImplementedException();
        }

        public Task<string> ResetPassword()
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangePassword()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Email
        public Task<string> SendEmailConfirmation()
        {
            throw new NotImplementedException();
        }
        public Task<string> ResendEmailConfirmation()
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangeEmail()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Private Methods

        private string CreateToken(IdentityUser authUser)
        {

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, authUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken(
               issuer: _configuration["JWT:ValidIssuer"],
               audience: _configuration["JWT:ValidAudience"],
               expires: DateTime.Now.AddHours(3),
               claims: authClaims,
               signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        
        #endregion
    }
}
