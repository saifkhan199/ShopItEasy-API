using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ProductServices.Services;
using System.Threading.Tasks;
using ProductServices.Model;
using ProductServices.ViewModel;
using System;
using ProductService.Model.Repository;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]

    public class ClothingProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ClothingProductController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpPost]
        public Task<List<ClothingProduct>> GetAllRequiredClothingProducts(List<Guid> productsIds)
        {
            try
            {

                var response = _productService.GetAllRequiredClothingProducts(productsIds);

                if (response == null)
                {
                    return null;
                }
                else
                    return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("GetProductByCategoryId/{id}")]
        public  IEnumerable<ClothingProduct> GetProductByCategoryId(Guid id)
        {
            try
            {

            var response =  _productService.GetProductByCategoryIdAsync(id);
            
            if (response == null)
            {
                return null;
            }
            else
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        [HttpGet("GetProductById/{id}")]
        public IEnumerable<ClothingProduct> GetProductById(Guid id)
        {
            try
            {

                var response = _productService.GetProductByIdAsync(id);

                if (response == null)
                {
                    return null;
                }
                else
                    return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public async Task<ActionResult<Category>> GetAllProductNameAsync()
        {
            var response = await _productService.GetAllProductNameAsync();
            if (response == null)
            {
                return NotFound("Category Not found");
            }
            else
                return Ok(response);
        }

        [HttpGet]
        
        [Route("Get")]
        public async Task<ActionResult<ClothingProduct>> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            if (response == null)
            {
                return NotFound("Product Not found");
            }
            else
                return Ok(response);
        }


        // POST: api/Product
        [HttpPost]
        [Route("AddClothing")]
        public async Task<ActionResult<ClothingProduct>> AddClothing([FromBody] ProductVM product)
        {

            if (product == null)
            {
                return BadRequest("Product is null.");
            }
            else
            {
                product.isActive = true;
                product.isDelete = false;
                
                return await _productService.AddProductAsync(product);
            }
           


        }
        [HttpPost]
        [Route("EditClothing")]
        public async Task<int> EditClothing([FromBody] ClothingProduct product)
        {

            return await _productService.EditClothing(product);
            
        }

        [HttpPut("{id}")]
        public async Task<ClothingProduct> DeleteAsync(Guid id)
        {
            var response = await _productService.DeleteProductAsync(id);
            return response;

        }
    }
}
