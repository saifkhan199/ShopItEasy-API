using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;
using UserService.Model.Repository;
using UserService.Repository.Interaface;
using UserService.ViewModel;

namespace UserService.Repository
{
    public class AdminRepository:DataRepository<Admin>,IAdminRepository
    {
        public AdminRepository(UserContext context) : base(context)
        {
        }

        public Task<Admin> GetAdminByIdAsync(Guid id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.AdminID.Equals(id));
        }


        public Task<Admin> AddAdminAsync(AdminViewModel Admin)
        {
           

            Guid guid = Guid.NewGuid();

            Admin Admin_obj = new Admin();

            Admin_obj.AdminID = guid;
            Admin_obj.Admin_Name = Admin.Admin_Name;
            Admin_obj.Password = Admin.Password;
            Admin_obj.Phone = Admin.Phone;
            Admin_obj.Email = Admin.Email;
            

            try
            {

                return AddAsync(Admin_obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<List<Admin>> GetAllAdminsAsync()
        {
            return GetAll().ToList();
        }
    }
}
