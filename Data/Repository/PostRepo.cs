using CantThinkOfATitle.Data;
using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;
using CantThinkOfATitle.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CantThinkOfATitle.Data.Repository
{
    public class PostRepo : IPostRepo
    {
        private readonly DataContext _dataContext;

        public PostRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Posts>> GetAllPosts()
        {
            var posts = await _dataContext.Posts
                .Include(t => t.User)
                .ToListAsync();

            return posts;
        }

    }
}
