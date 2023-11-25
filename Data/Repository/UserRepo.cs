//using CantThinkOfATitle.Data;
//using CantThinkOfATitle.Data.Repository.Interfaces;
//using CantThinkOfATitle.DTOs;
//using CantThinkOfATitle.Models;
//using CantThinkOfATitle.Responses;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.EntityFrameworkCore;

//namespace CantThinkOfATitle.Data.Repository
//{
//    public class UserRepo : IUserRepo
//    {
//        private readonly DataContext _dataContext;
//        private readonly IGenericRepo<User> _genericRepo;

//        public UserRepo(DataContext dataContext)
//        {
//            _dataContext = dataContext;
//            _genericRepo = new GenericRepo<User>(_dataContext);
//        }


//        public async Task<List<User>> GetAllUsers()
//        {
//            var users = await _genericRepo.GetAll();
//            //var users = await _dataContext.Users.ToListAsync();

//            return users;
//        }

//        public async Task<User> GetUserByEmail(string email)
//        {
//            var users = await _dataContext.Users.SingleOrDefaultAsync(user => user.Email == email);

//            return users;
//        }

//        public async Task<User> AddUser(User user)
//        {
//            await _dataContext.AddAsync(user);
//            _dataContext.SaveChanges();

//            return user;
//        }

//        public async Task<User> UpdateUser(User user)
//        {
//            var test = await _dataContext.Users.SingleOrDefaultAsync(dbuser => dbuser.Email == user.Email);
//            test.Email = user.Email;
//            await _dataContext.SaveChangesAsync();
//            return test;
//        }

//        public async Task<User> DeleteUser(string email)
//        {
//            var test = await _dataContext.Users.SingleOrDefaultAsync(dbuser => dbuser.Email == email);
//            _dataContext.Users.Remove(test);
//            await _dataContext.SaveChangesAsync();
//            return test;
//        }
//    }
//}
