using System.Security.Claims;
using CantThinkOfATitle.Services.Interfaces.Auth;
using CantThinkOfATitle.Responses.Auth;
using CantThinkOfATitle.DTOs.Auth;

namespace CantThinkOfATitle.Services.Auth
{
    public class AuthenticationService : IAuthenticationService

    {
        public Task<RegisterUserResponse<RegisterUserDTO>> Registration(RegisterUserDTO newUser)
        {
            throw new NotImplementedException();
        }

        #region Login/Logout

        public Task<LoginResponse<LoginDTO>> Login(LoginDTO user)
        {
            throw new NotImplementedException();
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

    }
}
