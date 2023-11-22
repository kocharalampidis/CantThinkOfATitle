using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;

namespace CantThinkOfATitle.Data.Repository
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<User> AddUser(User user);

        Task<User> UpdateUser(User user);
    }
}