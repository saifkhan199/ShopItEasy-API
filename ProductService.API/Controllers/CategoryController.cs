using Microsoft.AspNetCore.Mvc;
using ProductServices.Model;
using ProductServices.Services;
using ProductServices.ViewModel;
using System;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;

        }


        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<ActionResult<Category>> GetAllCategories()
        {
            var response = await _CategoryService.GetAllCategoriesAsync();
            if (response == null)
            {
                return NotFound("Category Not found");
            }
            else
                return Ok(response);
        }

        [HttpGet("GetAllCategoriesNameAsync")]
        public async Task<ActionResult<Category>> GetAllCategoriesNameAsync()
        {
            var response = await _CategoryService.GetAllCategoriesNameAsync();
            if (response == null)
            {
                return NotFound("Category Not found");
            }
            else
                return Ok(response);
        }

        [HttpPost]
        public async Task<string> POST([FromBody] CategoryVM Category)
        {

            if (Category == null)
            {
                return "Category is null";
            }
            else
            {
               
                return await _CategoryService.AddCategoryAsync(Category);
            }

        }

        [HttpPut("{id}")]
        public async Task<int> DeleteAsync(Guid id)
        {
            var response = await _CategoryService.DeleteCategoryAsync(id);
            return response;

        }

        [HttpPut("editCategory")]
        public async Task<int> editCategory(Category category)
        {
            var response = await _CategoryService.editCategory(category);
            return response;

        }
    }
 }
