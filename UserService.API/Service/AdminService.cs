using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;
using UserService.Repository.Interaface;
using UserService.Service.Interface;
using UserService.ViewModel;

namespace UserService.Service
{
    public class AdminService:IAdminService
    {
        private readonly IAdminRepository _AdminRepository;

        public AdminService(IAdminRepository AdminRepository)
        {
            _AdminRepository = AdminRepository;
        }

        public async Task<Admin> GetAdminsByIdAsync(Guid id)
        {
            return await _AdminRepository.GetAdminByIdAsync(id);
        }

        public async Task<Admin> AddAdminAsync(AdminViewModel Admin)
        {


            return await _AdminRepository.AddAdminAsync(Admin);


        }


        public async Task<List<Admin>> GetAllAdminsAsync()
        {

            return await _AdminRepository.GetAllAdminsAsync();
        }


    }
}
