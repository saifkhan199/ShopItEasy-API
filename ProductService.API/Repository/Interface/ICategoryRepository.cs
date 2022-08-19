using ProductService.Model.Repository;
using ProductServices.Model;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Repository.Interface
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category> GetCategoryById(Guid id);
        Task<string> AddCategoryAsync(CategoryVM Category);
        Task<List<Category>> GetAllCategoriesAsync();
        List<KeyValuePair<Guid, string>> GetAllCategoriesNameAsync();
        Task<int> DeleteCategoryAsync(Guid id);
        Task<int> editCategory(Category category);
    }
}
