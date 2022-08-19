using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.API.ViewModel;
using UserService.Model;
using UserService.ViewModel;

namespace UserService.Repository.Interface
{
   
    public interface IMailRepository
    {
        Task SendResetEmail(MailRequest mailRequest);
        Task<bool> sendNewOrderEmail(OrderEmailModel emailObj);
        Task<bool> sendCustomerResponseEmail(UserResponseVM emailObj);

        Task SendSignupCodeEmail(MailRequest mailRequest);

    }
    
}
