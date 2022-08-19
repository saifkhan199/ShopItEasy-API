
using System.Threading.Tasks;
using MimeKit;
using System.IO;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using UserService.Service.Interface;
using UserService.Model;
using UserService.Repository.Interface;
using UserService.ViewModel;
using System.Collections.Generic;
using UserService.API.ViewModel;

namespace UserService.Service
{
    public class MailService : IMailService
    {
        private readonly IMailRepository _mailRepository;

        public MailService(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }


        public Task SendResetEmail(MailRequest mailRequest)
        {
            return _mailRepository.SendResetEmail(mailRequest);
        }
        public Task SendSignupCodeEmail(MailRequest mailRequest)
        {
            return _mailRepository.SendSignupCodeEmail(mailRequest);
        }
        

        public Task<bool> sendNewOrderEmail(OrderEmailModel emailObj)
        {
            return _mailRepository.sendNewOrderEmail(emailObj);
        }
        public Task<bool> sendCustomerResponseEmail(UserResponseVM emailObj)
        {
            return _mailRepository.sendCustomerResponseEmail(emailObj);
        }
    }
}

