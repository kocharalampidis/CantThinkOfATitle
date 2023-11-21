using AutoMapper;
using CantThinkOfATitle.Data;
using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;
using CantThinkOfATitle.Repository;
using CantThinkOfATitle.Responses;
using CantThinkOfATitle.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CantThinkOfATitle.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dbContext;
        private readonly IUserRepo _userRepo;

        public UserService(
            IMapper mapper,
            IUserRepo repo,
            DataContext context
            )
        {
            //_mapper = mapper;
            _dbContext = context;
            _userRepo = repo;
        }

        public async Task<UserResponse<List<UserResponseDTO>>> GetAllUsers()
        {
            var response = new UserResponse<List<UserResponseDTO>>();

            try
            {
                var test = await _userRepo.GetAllUsers();
                if (test.Count == 0)
                {
                    response.Success = false;
                    return response;
                }
                response.Success = true;
                return response;
            }
            catch (Exception)
            {

                response.Success = false;
                return response;
            }
            //var test = await _dbContext.Users.ToListAsync();

            //  response.Data = _mapper.Map<List<UserResponseDTO>>(test);

            //return response;
            //throw new NotImplementedException();

        }

        public Task<UserResponse<UserResponseDTO>> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse<UserResponseDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAllUsers2()
        {
            var test = await _userRepo.GetAllUsers2();
            return test;
            //var response = new UserResponse<List<UserResponseDTO>>();

            //try
            //{
            //    var test = await _userRepo.GetAllUsers2();
            //    //if (test.)
            //    //{
            //    //    response.Success = false;
            //    //    return t;
            //    //}
            //    //response.Success = true;
            //    return test;
            //}
            //catch (Exception)
            //{

            //    //response.Success = false;
            //    //return response;
            //    return
            //}
        }
    }
}
