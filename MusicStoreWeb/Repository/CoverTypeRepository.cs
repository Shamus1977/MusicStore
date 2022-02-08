using MusicStoreWeb.Data;
using MusicStoreWeb.Models;
using MusicStoreWeb.Repository.IRepository;

namespace MusicStoreWeb.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private AppDbContext? _dbContext;
        public CoverTypeRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }
        public void Update(CoverType coverType)
        {
            _dbContext?.Update(coverType);
        }
    }
}
