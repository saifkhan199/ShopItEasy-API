using ProductServices.ViewModel;
using ProductServices.Model;
using ProductServices.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Services
{
    public class ProductSerivce:IProductService
    {

        private readonly IProductRepository _productRepository;
       
        public ProductSerivce(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ClothingProduct> GetProductByCategoryIdAsync(Guid id)
        {
            return _productRepository.GetProductByCategoryIdAsync(id);
        }
        public IEnumerable<ClothingProduct> GetProductByIdAsync(Guid id)
        {
            return _productRepository.GetProductByIdAsync(id);
        }

        public Task<List<ClothingProduct>> GetAllRequiredClothingProducts(List<Guid> productIds)
        {
             return _productRepository.GetAllRequiredClothingProducts(productIds);
        }

        public async Task<ClothingProduct> AddProductAsync(ProductVM product)
        {
             return await _productRepository.AddProductAsync(product);
           
        }
        public async Task<int> EditClothing (ClothingProduct product)
        {
            return await _productRepository.EditClothing(product);
        }
        public async Task<bool> UpdateInventory(AddOrderVM product)
        {
            return await _productRepository.UpdateInventory(product);

        }

        public async Task<List<ClothingProduct>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<ClothingProduct> DeleteProductAsync(Guid id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }
        public async Task<List<KeyValuePair<Guid, string>>> GetAllProductNameAsync()
        {
            return _productRepository.GetAllProductNameAsync();
        }
    }
}
