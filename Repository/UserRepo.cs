using CantThinkOfATitle.Data;
using CantThinkOfATitle.Models;
using Microsoft.EntityFrameworkCore;

namespace CantThinkOfATitle.Repository
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

        public async Task<User> GetAllUsers2()
        {
            var users = await _dataContext.Users.FirstOrDefaultAsync();

            return users;
        }
    }
}
