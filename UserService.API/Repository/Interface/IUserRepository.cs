using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;
using UserService.Model.Repository;
using UserService.ViewModel;

namespace UserService.Repository.Interaface
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<LoginUserViewModel> GetUserByIdAsync(LoginUserViewModel user);
        Task<User> AddUserAsync(UserViewModel User);
        Task<List<string>> GetAllAdminEmailsAsync();
        Task<List<User>> GetAllCustomersAsync();
        Task<User> ChangePassAsync(ChangePasswordViewModel chP);
    }
}
