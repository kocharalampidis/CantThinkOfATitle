using CantThinkOfATitle.Models;

namespace CantThinkOfATitle.Repository
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetAllUsers2();
    }
}