using CantThinkOfATitle.DTOs.Auth;
using CantThinkOfATitle.Responses.Auth;

namespace CantThinkOfATitle.Services.Interfaces.Auth
{
    public interface IAuthenticationService
    {
        Task<RegisterUserResponse<RegisterUserDTO>> Registration(RegisterUserDTO registerUserDTO);

        #region Login/Logout 

        Task<LoginResponse<LoginDTO>> Login(LoginDTO user);

        Task<LoginResponse<LoginDTO>> LoginAdmin(LoginDTO user);

        Task<string> Logout();

        #endregion

        #region Change/Reset Password

        Task<string> ChangePassword();

        Task<string> ResetPassword();

        Task<string> ForgotPassword();

        #endregion

        #region Email
        
        Task<string> SendEmailConfirmation();

        Task<string> ResendEmailConfirmation();

        Task<string> ChangeEmail();
        
        #endregion


    }
}
