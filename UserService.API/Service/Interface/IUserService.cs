using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;
using UserService.ViewModel;

namespace UserService.Service.Interface
{
    public interface IUserService
    {
        Task<User> AddUserAsync(UserViewModel Users);

        Task<LoginUserViewModel> GetUsersByIdAsync(LoginUserViewModel Users);

        Task<List<User>> GetAllCustomersAsync();
        Task<List<string>> GetAllAdminEmailsAsync();

        Task<User> ChangePassAsync(ChangePasswordViewModel chp);

    }
}
