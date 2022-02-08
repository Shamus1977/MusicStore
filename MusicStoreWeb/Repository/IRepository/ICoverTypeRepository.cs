using MusicStoreWeb.Models;
using System.Linq.Expressions;

namespace MusicStoreWeb.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}
