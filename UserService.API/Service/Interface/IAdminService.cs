using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;
using UserService.ViewModel;

namespace UserService.Service.Interface
{
    public interface IAdminService
    {
        Task<Admin> AddAdminAsync(AdminViewModel Admins);

        Task<Admin> GetAdminsByIdAsync(Guid id);

        Task<List<Admin>> GetAllAdminsAsync();

    }
}
