using CantThinkOfATitle.Data.Repository.Interfaces;
using CantThinkOfATitle.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CantThinkOfATitle.Data.Repository
{
    public class PostRepo : IPostRepo
    {
        private readonly DataContext _dataContext;
        private readonly IGenericRepo<Posts> _genericRepo;

        public PostRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
            _genericRepo = new GenericRepo<Posts>(dataContext);

        }

        public async Task<List<Posts>> GetAllPosts()
        {
            var posts = await _dataContext.Posts
                .Include(post => post.User)
                .ToListAsync();

            return posts;
        }


        public async Task<List<Posts>> GetSinglePostById(int id, string[] tablesToInclude = null)
        {
            Expression<Func<Posts, bool>> predicate = (i => i.Id == id);
            return await _genericRepo.Single(predicate, tablesToInclude);
        }

        public async Task<List<Posts>> GetUserPosts(int id)
        {

            var posts = await _dataContext.Posts
                .Include(post => post.User)
                .Where(post => post.User.Id == id)
                .ToListAsync();

            return posts;

        }
    }
}
