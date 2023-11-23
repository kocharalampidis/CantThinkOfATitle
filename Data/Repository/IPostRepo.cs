using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;

namespace CantThinkOfATitle.Data.Repository
{
    public interface IPostRepo
    {
        Task<List<Posts>> GetAllPosts();

        //Task<User> GetUserByEmail(string email);

        //Task<User> AddUser(User user);

        //Task<User> UpdateUser(User user);

        //Task<User> DeleteUser(string email);
    }
}