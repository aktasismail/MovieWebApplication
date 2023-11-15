using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, new()
    {
        protected readonly MovieDbContext _db;
        protected RepositoryBase(MovieDbContext db)
        {
            _db = db;
        }
        public IQueryable<T> GetAll(bool trackcanges)
        {
            return trackcanges ? _db.Set<T>() : _db.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindbyId(Expression<Func<T, bool>> expression, bool trackcanges)
        {
            return trackcanges ?
                _db.Set<T>().Where(expression) :
                _db.Set<T>().Where(expression).AsNoTracking();
        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
    }
}
