using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.API.ViewModel;
using UserService.Model;
using UserService.ViewModel;

namespace UserService.Service.Interface
{
    public interface IMailService
    {
        Task SendResetEmail(MailRequest mailRequest);
        Task<bool> sendNewOrderEmail(OrderEmailModel emailObj);

        Task SendSignupCodeEmail(MailRequest mailRequest);
        Task<bool> sendCustomerResponseEmail(UserResponseVM emailObj);

    }
    
}
