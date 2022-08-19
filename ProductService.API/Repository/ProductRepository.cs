using ProductService.Model.Repository;
using ProductServices.Model;
using ProductServices.ViewModel;
using ProductServices.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ProductServices.Repository
{
    public class ProductRepository : DataRepository<ClothingProduct>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }

        public IEnumerable<ClothingProduct> GetProductByCategoryIdAsync(Guid id)
        {
            var a = GetAll().ToList().Where(x =>x.categoryID.Equals(id));
            return a;

        }

        public IEnumerable<ClothingProduct> GetProductByIdAsync(Guid id)
        {
            var a = GetAll().ToList().Where(x => x.ProductID.Equals(id));
            return a;
        }

        public async Task<List<ClothingProduct>> GetAllRequiredClothingProducts(List<Guid> productIds)
        {
            var a = GetAll().ToList().Where(x => productIds.Contains(x.ProductID)).ToList();
            return a;
        }
        public async Task<bool> UpdateInventory(AddOrderVM product)
        {
            Dictionary<Guid,int> productIds = new Dictionary<Guid,int>();
            foreach(var item in product.purchasedItems)
            {
                productIds.Add(Guid.Parse(item.productID),item.quantity);
            }

            if (product.purchasedItems!= null)
            {
                try
                {
                    foreach (var item in productIds)
                    {
                        List<ClothingProduct> productInDb = _context.ClothingProducts.Where(p => p.ProductID.Equals(item.Key)).ToList();
                        productInDb[0].Quantity = productInDb[0].Quantity - item.Value;

                        _context.SaveChangesAsync();
                    }


                    return true;
                }
                catch(Exception e)
                {
                    throw;
                }
            }
            return false;
        }
        public async Task<int> EditClothing(ClothingProduct product)
        {
           
            await UpdateAsync(product);
            var response =await _context.SaveChangesAsync();
            return response;
            
        }
        public Task<ClothingProduct> AddProductAsync(ProductVM clothing)
        {
            var config = new MapperConfiguration(cfg =>

                  cfg.CreateMap<ProductVM, ClothingProduct>()

              );

            var mapper = new Mapper(config);
            var product = mapper.Map<ClothingProduct>(clothing);

            Guid Id = Guid.NewGuid();
            product.ProductID = Id;

            
            try
            {
                
                return AddAsync(product);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }


        public async Task<List<ClothingProduct>> GetAllProductsAsync()
        {
            try
            {
                var data = GetAll().ToList();
                return data;
            }
            catch(Exception e)
            {
                throw;
            }
           
        }
        public async Task<ClothingProduct> DeleteProductAsync(Guid id)
        {
           
            if (id.Equals(null))
            {
                throw new ArgumentNullException("ID must not be null");
            }
            else
            {
                var product = _context.Set<ClothingProduct>().FirstOrDefault(a => a.ProductID == id);
                product.isDeleted = true;
                await _context.SaveChangesAsync();

                return product;
            }
            
        }
        public List<KeyValuePair<Guid, string>> GetAllProductNameAsync()
        {

            var data = GetAll();
            var Active = data.Where(x => x.isDeleted == false);
            var list = new List<KeyValuePair<Guid, string>>();


            foreach (var item in data)
            {
                {
                    list.Add(new KeyValuePair<Guid, string>(item.ProductID, item.productName));

                }
            }

            return list;
        }
    }
}
