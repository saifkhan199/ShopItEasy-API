using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProductService.Model.Repository;
using ProductServices.Model;
using ProductServices.ViewModel;

namespace ProductServices.Repository.Interface
{
    public interface IProductRepository:IGenericRepository<ClothingProduct>
    {
        IEnumerable<ClothingProduct> GetProductByCategoryIdAsync(Guid id);
        IEnumerable<ClothingProduct> GetProductByIdAsync(Guid id);
        Task<bool> UpdateInventory(AddOrderVM product);
        Task<List<ClothingProduct>> GetAllRequiredClothingProducts(List<Guid> productIds);
        Task<ClothingProduct> AddProductAsync(ProductVM album);
        Task<int> EditClothing(ClothingProduct product);
        Task<List<ClothingProduct>> GetAllProductsAsync();
        Task<ClothingProduct> DeleteProductAsync(Guid id);
        List<KeyValuePair<Guid, string>> GetAllProductNameAsync();
    }
}
