using CantThinkOfATitle.Data;
using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;
using CantThinkOfATitle.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CantThinkOfATitle.Data.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _dataContext;

        public UserRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _dataContext.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUserById(int id)
        {
            var users = await _dataContext.Users.FindAsync(id);

            return users;
        }

        public async Task<User> AddUser(User user)
        {
            await _dataContext.AddAsync(user);
            _dataContext.SaveChanges();

            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var test = await _dataContext.Users.FindAsync(user.Id);
            test.Email = user.Email;
            await _dataContext.SaveChangesAsync();
            return test;
        }

    }
}
