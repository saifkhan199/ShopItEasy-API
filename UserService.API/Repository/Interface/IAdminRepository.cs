using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;
using UserService.Model.Repository;
using UserService.ViewModel;

namespace UserService.Repository.Interaface
{
    public interface IAdminRepository:IGenericRepository<Admin>
    {
        Task<Admin> GetAdminByIdAsync(Guid id);
        Task<Admin> AddAdminAsync(AdminViewModel admin);
        Task<List<Admin>> GetAllAdminsAsync();
    }
}
