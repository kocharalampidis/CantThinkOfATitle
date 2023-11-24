using CantThinkOfATitle.Data.Repository.Interfaces;
using CantThinkOfATitle.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace CantThinkOfATitle.Data.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DataContext _dataContext;

        public GenericRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dataContext
                .Set<T>()
                //.Include()
                .ToListAsync();
        }

        public async Task<List<T>> Single(Expression<Func<T, bool>> predicate, params string[] includes)
        {

            IQueryable<T> query = _dataContext.Set<T>();
            query = query.Where(predicate); 

            for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }

            List<T> result = await query.ToListAsync();
            return result;
        }
    
    }
}
