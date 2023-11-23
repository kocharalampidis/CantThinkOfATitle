using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;
using CantThinkOfATitle.Responses;

namespace CantThinkOfATitle.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse<List<UserResponseDTO>>> GetAllUsers();

        Task<UserResponse<UserResponseDTO>> GetUserByEmail(string email);

        Task<UserResponse<UserResponseDTO>> AddUser(User user);

        Task<UserResponse<UserResponseDTO>> UpdateUser(UserDTO user, string email);

        Task<UserResponse<UserResponseDTO>> DeleteUser(string email);
    }
}
