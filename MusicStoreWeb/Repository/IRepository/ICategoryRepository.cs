using MusicStoreWeb.Models;

namespace MusicStoreWeb.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

    }
}
