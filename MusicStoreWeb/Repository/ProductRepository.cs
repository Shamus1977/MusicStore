using MusicStoreWeb.Data;
using MusicStoreWeb.Models;
using MusicStoreWeb.Repository.IRepository;

namespace MusicStoreWeb.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext? _dbContext;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }
        public void Update(Product product)
        {
            var objFromDb = _dbContext?.Products?.FirstOrDefault(p => p.Id == product.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = product.Title;
                objFromDb.Description = product.Description;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.AddedDate = product.AddedDate;
                objFromDb.BandId = product.BandId;
                objFromDb.Released = product.Released;
                objFromDb.Members = product.Members;
                objFromDb.Label = product.Label;
                objFromDb.Length = product.Length;
                objFromDb.MediaType = product.MediaType;
                objFromDb.Tracks = product.Tracks;
                objFromDb.NumberOfTracks = product.NumberOfTracks;
                objFromDb.CoverTypeId = product.CoverTypeId;
                objFromDb.AddedDate = objFromDb.AddedDate;
                if(product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
