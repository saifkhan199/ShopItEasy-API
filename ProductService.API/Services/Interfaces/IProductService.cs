using ProductServices.Model;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Services
{
    public interface IProductService
    {
        Task<ClothingProduct> AddProductAsync(ProductVM albums);

        IEnumerable<ClothingProduct> GetProductByCategoryIdAsync(Guid id);
        IEnumerable<ClothingProduct> GetProductByIdAsync(Guid id);

        Task<bool> UpdateInventory(AddOrderVM product);
        Task<int> EditClothing(ClothingProduct product);

        Task<List<ClothingProduct>> GetAllRequiredClothingProducts(List<Guid> productIds);

        Task<List<ClothingProduct>> GetAllProductsAsync();
        Task<ClothingProduct> DeleteProductAsync(Guid id);
        Task<List<KeyValuePair<Guid, string>>> GetAllProductNameAsync();
    }
}
