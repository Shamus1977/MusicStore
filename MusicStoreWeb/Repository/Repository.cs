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

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if(includeProperties != null)
            {
                foreach(var property in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            if(includeProperties != null)
            {
                foreach(var property in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
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
