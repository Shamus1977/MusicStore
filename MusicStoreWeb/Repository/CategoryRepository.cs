using MusicStoreWeb.Data;
using MusicStoreWeb.Models;
using MusicStoreWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace MusicStoreWeb.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext? _dbContext;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }
        public void Update(Category category)
        {
            _dbContext?.Update(category);
        }
    }
}
