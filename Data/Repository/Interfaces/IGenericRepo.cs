using System.Linq.Expressions;

namespace CantThinkOfATitle.Data.Repository.Interfaces
{
    public interface IGenericRepo<T> where T : class 
    {
        Task<List<T>> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        Task<List<T>> Single(Expression<Func<T, bool>> predicate, params string[] includes);

        //IEnumerable<T> FindAll();

        //IEnumerable<T> FindById(int id);

        //IEnumerable<T> FindByName(string name);
    }
}
