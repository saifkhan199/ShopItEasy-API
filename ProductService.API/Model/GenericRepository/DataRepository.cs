using Microsoft.EntityFrameworkCore;
using ProductServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProductService.Model.Repository
{
    public class DataRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ProductContext _context;
       
        public DataRepository(ProductContext context)
        {
            _context = context;
            
        }
        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
            
        }
       

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(entity);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch(Exception e)
                {
                    throw new Exception($"{nameof(entity)} could not be saved: {e.Message}");
                }
               

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
            
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                 await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }




    }
}
