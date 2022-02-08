using MusicStoreWeb.Data;
using MusicStoreWeb.Repository.IRepository;

namespace MusicStoreWeb.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext? _dbContext;
        public ICategoryRepository CategoryRepository { get; private set; }
        public ICoverTypeRepository CoverTypeRepository { get; private set;}
        public UnitOfWork(AppDbContext context)
        {
            _dbContext = context;
            this.CategoryRepository = new CategoryRepository(context);
            this.CoverTypeRepository = new CoverTypeRepository(context);
        }
        public void Save()
        {
            _dbContext?.SaveChanges();
        }
    }
}
