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
    public class UserService:IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<LoginUserViewModel> GetUsersByIdAsync(LoginUserViewModel Users)
        {
            return await _UserRepository.GetUserByIdAsync(Users);
        }
       
        public async Task<User> AddUserAsync(UserViewModel User)
        {
            var users =await _UserRepository.GetAllCustomersAsync();
            var isUserExists = users.Where(u => u.Email == User.Email).ToList();
            if (isUserExists.Count>0)
            {
                return new User();
            }
            return await _UserRepository.AddUserAsync(User);

        }

        public async Task<User> ChangePassAsync(ChangePasswordViewModel chp)
        {
            var response= await _UserRepository.ChangePassAsync(chp);
            return response;
        }

        public async Task<List<string>> GetAllAdminEmailsAsync()
        {
            return await _UserRepository.GetAllAdminEmailsAsync();
        }
       
        public async Task<List<User>> GetAllCustomersAsync()
        {
            return await _UserRepository.GetAllCustomersAsync();
        }

       
    }
}
