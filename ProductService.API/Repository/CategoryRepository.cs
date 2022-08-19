using Microsoft.EntityFrameworkCore;
using ProductService.Model.Repository;
using ProductServices.Model;
using ProductServices.Repository.Interface;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProductServices.Repository
{
    public class CategoryRepository : DataRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductContext context) : base(context)
        {
           
        }

        public async Task<string> AddCategoryAsync(CategoryVM Category)
        {
            Category newCategory = new Category();
            newCategory.CategoryId = Guid.NewGuid();
            newCategory.CategoryName = Category.Category_Name;
            newCategory.isActive = Category.isActive;

            try
            {
               var categoryInDb =await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == Category.Category_Name);
                if (categoryInDb == null)
                {
                    var response=await AddAsync(newCategory);
                    if (response.CategoryName != "")
                    {
                        return "Category Added Successfully";
                    }
                }
                else
                {
                    return "Category Already Exists";
                }


                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return GetAll().ToList();
        }

        public List<KeyValuePair<Guid, string>> GetAllCategoriesNameAsync()
        {
            try
            {

                var data = GetAll();
                var Active = data.Where(x => x.isActive == true);
                var list = new List<KeyValuePair<Guid, string>>();


                foreach (var item in Active)
                {
                    {
                        list.Add(new KeyValuePair<Guid, string>(item.CategoryId, item.CategoryName));

                    }
                }

                return list;
            }
            catch(Exception e)
            {
                throw;
            }
            
        }

        public Task<Category> GetCategoryById(Guid id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.CategoryId.Equals(id));
        }

        public async Task<int> DeleteCategoryAsync(Guid id)
        {

            if (id.Equals(null))
            {
                throw new ArgumentNullException("ID must not be null");
            }
            else
            {
                var category =await _context.Categories.FirstOrDefaultAsync(a => a.CategoryId == id);
                category.isActive = false;
                return await _context.SaveChangesAsync();
            }

        }
        public async Task<int> editCategory(Category category)
        {

            if (category.CategoryId.Equals(null))
            {
                throw new ArgumentNullException("ID must not be null");
            }
            else
            {
                var categoryInDb =await _context.Categories.FirstOrDefaultAsync(a => a.CategoryId == category.CategoryId);
                categoryInDb.CategoryName = category.CategoryName;
                categoryInDb.isActive = category.isActive;
                return await _context.SaveChangesAsync();
            }

        }
    }
}