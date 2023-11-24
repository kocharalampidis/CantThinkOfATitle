using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;

namespace CantThinkOfATitle.Data.Repository.Interfaces
{
    public interface IPostRepo
    {
        Task<List<Posts>> GetAllPosts();

        Task<List<Posts>> GetUserPosts(int id);

        Task<List<Posts>> GetSinglePostById(int id, string[] tablesToInclude = null);

        //Task<User> GetUserByEmail(string email);

        //Task<User> AddUser(User user);

        //Task<User> UpdateUser(User user);

        //Task<User> DeleteUser(string email);
    }
}