using ProductServices.Model;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Services
{
   public interface ICategoryService
    {
        Task<string> AddCategoryAsync(CategoryVM Category);

        Task<Category> GetCategoriesByIdAsync(Guid id);

        Task<List<Category>> GetAllCategoriesAsync();

        Task<List<KeyValuePair<Guid, string>>> GetAllCategoriesNameAsync();

        Task<int> DeleteCategoryAsync(Guid id);

        Task<int> editCategory(Category category);
    }
}
