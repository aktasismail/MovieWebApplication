using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(bool trackcanges);
        IQueryable<T> FindbyId(Expression<Func<T,bool>> expression,bool trackcanges);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
