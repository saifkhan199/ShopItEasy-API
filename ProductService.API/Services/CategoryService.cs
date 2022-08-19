using ProductServices.Model;
using ProductServices.Repository.Interface;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryService(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public async Task<Category> GetCategoriesByIdAsync(Guid id)
        {
            return await _CategoryRepository.GetCategoryById(id);
        }

        public async Task<string> AddCategoryAsync(CategoryVM Category)
        {


            return await _CategoryRepository.AddCategoryAsync(Category);


        }


        public async Task<List<Category>> GetAllCategoriesAsync()
        {

            return await _CategoryRepository.GetAllCategoriesAsync();
        }



        public async Task<List<KeyValuePair<Guid, string>>> GetAllCategoriesNameAsync()
        {
            return _CategoryRepository.GetAllCategoriesNameAsync();
        }

        public async Task<int> DeleteCategoryAsync(Guid id)
        {
            return await _CategoryRepository.DeleteCategoryAsync(id);
            
        }

        public async Task<int> editCategory(Category category)
        {
            return await _CategoryRepository.editCategory(category);

        }



    }
}

