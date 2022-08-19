using ProductServices.Model;
using ProductServices.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Services
{
    public class UserViewService:IUserViewService
    {
        private readonly IUserViewRepository _UserViewRepository;

        public UserViewService(IUserViewRepository UserViewRepository)
        {
            _UserViewRepository = UserViewRepository;
        }

        public IEnumerable<ClothingProduct> searchQueryAsync(string keyword)
        {
            try
            {
                return _UserViewRepository.searchQueryAsync(keyword);
            }
            catch(Exception e)
            {
                throw e;
            }
           
           
        }

        public IEnumerable<Object> cityWiseStatsAsync()
        {

            try
            {
                return _UserViewRepository.cityWiseStatsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Object> salesStatsAsync()
        {
            try
            {
                return _UserViewRepository.salesStatsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable pendingOrdersAsync()
        {
            try
            {
                return _UserViewRepository.pendingOrdersAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
