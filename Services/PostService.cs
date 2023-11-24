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
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepo _postRepo;

        public PostService(IMapper mapper, IPostRepo postRepo)
        {
            _mapper = mapper;
            _postRepo = postRepo;
        }

        public async Task<PostResponse<List<PostResponseDTO>>> GetAllPosts()
        {
            var response = new PostResponse<List<PostResponseDTO>>();
            try
            {
                var posts = await _postRepo.GetAllPosts();

                response.Data = _mapper.Map<List<PostResponseDTO>>(posts);
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;

                return response;
            }


        }

        public async Task<PostResponse<List<PostResponseDTO>>> GetUserPosts(int id)
        {
            var response = new PostResponse<List<PostResponseDTO>>();
            try
            {
                var posts = await _postRepo.GetUserPosts(id);

                response.Data = _mapper.Map<List<PostResponseDTO>>(posts);
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;

                return response;
            }
        }

        public async Task<PostResponse<List<PostResponseDTO>>> GetPostsById(int id)
        {
            var response = new PostResponse<List<PostResponseDTO>>();
            try
            {
                var posts = await _postRepo.GetSinglePostById(id, ["User"]);

                response.Data = _mapper.Map<List<PostResponseDTO>>(posts);
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;

                return response;
            }
        }
    }
}
