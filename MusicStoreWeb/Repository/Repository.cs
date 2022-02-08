using Microsoft.EntityFrameworkCore;
using MusicStoreWeb.Data;
using MusicStoreWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace MusicStoreWeb.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        internal DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _dbContext = context;
            this._dbSet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault()!;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
