using MusicStoreWeb.Models;

namespace MusicStoreWeb.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
