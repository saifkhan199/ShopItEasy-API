using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserService.API.ViewModel;
using UserService.Model;
using UserService.Service.Interface;
using UserService.ViewModel;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly IUserService _userService;
        private readonly IMemoryCache _cache;

        public MailController(IMemoryCache cache, IMailService mailService, IUserService userService)
        {
            _mailService = mailService;
            _userService = userService;
            _cache = cache;
        }

        [HttpPost("SendResetEmail")]
        public async Task<IActionResult> SendResetEmail(object emailObj)
        {

            var emailDetails = JsonConvert.DeserializeObject<dynamic>(emailObj.ToString());
            var email = emailDetails.email;
            var subject = emailDetails.subject;


            Random generator = new Random();
            String code = generator.Next(0, 1000000).ToString("D6");
            _cache.Set("resetCode", code, TimeSpan.FromMinutes(2)); //it will be checked on change password call

            MailRequest mr = new MailRequest();
            mr.ToEmail = email;
            mr.Subject = subject;
            mr.Body = code;
            try
            {
                await _mailService.SendResetEmail(mr);
                return Ok(code);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost("SendSignupCodeEmail")]
        public async Task<IActionResult> SendSignupCodeEmail(object emailObj)
        {

            var emailDetails = JsonConvert.DeserializeObject<dynamic>(emailObj.ToString());
            var email = emailDetails.email;
            var subject = emailDetails.subject;


            Random generator = new Random();
            String code = generator.Next(0, 1000000).ToString("D6");


            MailRequest mr = new MailRequest();
            mr.ToEmail = email;
            mr.Subject = subject;
            mr.Body = code;
            try
            {
                await _mailService.SendSignupCodeEmail(mr);
                return Ok(code);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost("sendNewOrderEmail")]
        public async Task<bool> sendNewOrderEmail(OrderEmailModel emailObj)
        {
            try
            {
                emailObj.emailRecipients = await _userService.GetAllAdminEmailsAsync();
                var result = await _mailService.sendNewOrderEmail(emailObj);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost("sendCustomerResponseEmail")]
        public async Task<bool> sendCustomerResponseEmail(UserResponseVM emailObj)
        {
            try
            {
                emailObj.recipients = await _userService.GetAllAdminEmailsAsync();

                var result = await _mailService.sendCustomerResponseEmail(emailObj);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
