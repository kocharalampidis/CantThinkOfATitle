using AutoMapper;
using CantThinkOfATitle.Data;
using CantThinkOfATitle.Data.Repository.Interfaces;
using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;
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
        private readonly IUserRepo _userRepo;

        public UserService(IMapper mapper, IUserRepo repo)
        {
            _mapper = mapper;
            _userRepo = repo;
        }

        public async Task<UserResponse<List<UserResponseDTO>>> GetAllUsers()
        {
            var response = new UserResponse<List<UserResponseDTO>>();

            try
            {
                var users = await _userRepo.GetAllUsers();
                if (users.Count == 0)
                {
                    response.Success = false;
                    return response;
                }

                response.Data = _mapper.Map<List<UserResponseDTO>>(users);
                response.Success = true;
                
                return response;
            }
            catch (Exception)
            {

                response.Success = false;
                return response;
            }
           

        }

        public async Task<UserResponse<UserResponseDTO>> GetUserByEmail(string email)
        {

            var response = new UserResponse<UserResponseDTO>();

            try
            {
                var user = await _userRepo.GetUserByEmail(email);
                
                if (user == null)
                {
                    response.Success = false;
                    return response;
                }

                response.Data = _mapper.Map<UserResponseDTO>(user);
                response.Success = true;

                return response;
            }
            catch (Exception)
            {

                response.Success = false;
                return response;
            }

        }

        public async Task<UserResponse<UserResponseDTO>> AddUser(User newUser)
        {
            
            var response = new UserResponse<UserResponseDTO>();

            try
            {
                var candidate = await _userRepo.AddUser(newUser);

                if (candidate == null)
                {
                    response.Success = false;
                    return response;
                }

                response.Data = _mapper.Map<UserResponseDTO>(candidate);
                response.Success = true;

                return response;
            }
            catch (Exception)
            {

                response.Success = false;
                return response;
            }

        }

        public async Task<UserResponse<UserResponseDTO>> UpdateUser(UserDTO user, string email)
        {
            var response = new UserResponse<UserResponseDTO>();

            try
            {

                if (user == null)
                {
                    response.Success = false;
                    response.Message = "User null";
                    return response;
                }
                
                var candidate = _mapper.Map<User>(user);
                
                await _userRepo.UpdateUser(candidate);

                response.Data = _mapper.Map<UserResponseDTO>(candidate);
                response.Success = true;

                return response;
            }
            catch (Exception)
            {

                response.Success = false;
                return response;
            }
        }
        
        public async Task<UserResponse<UserResponseDTO>> DeleteUser(string email)
        {
            var response = new UserResponse<UserResponseDTO>();

            try
            {
                //var test = await _userRepo.GetUserById(user.Id);

                await _userRepo.DeleteUser(email);

                //if (candidate == null)
                //{
                //    response.Success = false;
                //    return response;
                //}

                response.Success = true;

                return response;
            }
            catch (Exception)
            {

                response.Success = false;
                return response;
            }
        }

    }
}
