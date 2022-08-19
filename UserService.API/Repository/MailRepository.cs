using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using MailKit.Security;
using System.Threading.Tasks;
using UserService.Model;
using UserService.Repository.Interface;
using UserService.ViewModel;
using System.Reflection;
using System.Collections.Generic;
using UserService.API.ViewModel;

namespace UserService.Repository
{
    public class MailRepository:IMailRepository
    {
        private readonly MailSettings _mailSettings;
        public MailRepository(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendResetEmail(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));

            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            //if (mailRequest.Attachments != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in mailRequest.Attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }
            //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}
            try
            {
                //builder.HtmlBody = mailRequest.Body;

                //verbatim string is created using a special symbol @
                //don't change text spacing
                builder.TextBody =$@"Hi,
    
Please use this code {mailRequest.Body} to reset password of ShopItEasy account
        
Thanks
ShopItEasy Team
                    
                ";
                builder.Attachments.Add(@$"{System.IO.Directory.GetCurrentDirectory()}/Resources/logo.png");
               
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch(Exception e)
            {
                throw e;
            }
           
        }

        public async Task SendSignupCodeEmail(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));

            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            //if (mailRequest.Attachments != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in mailRequest.Attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }
            //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}
            try
            {
                //builder.HtmlBody = mailRequest.Body;

                //verbatim string is created using a special symbol @
                //don't change text spacing
                builder.TextBody = $@"Hi,
    
Thanks for joining ShopItEasy. Please Enter this code {mailRequest.Body} on signup form to confirm you email and to start shopping.
        
Thanks
ShopItEasy Team
                    
                ";
                builder.Attachments.Add(@$"{System.IO.Directory.GetCurrentDirectory()}/Resources/logo.png");

                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> sendCustomerResponseEmail(UserResponseVM emailObj)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            if (emailObj.recipients.Count > 0)
            {
                foreach (var emailAddress in emailObj.recipients)
                {
                    email.To.Add(MailboxAddress.Parse(emailAddress));
                }

                email.Subject = emailObj.subject;
                var builder = new BodyBuilder();

                try
                {
                    //builder.HtmlBody = mailRequest.Body;

                    //verbatim string is created using a special symbol @
                    //don't change text spacing
                    builder.TextBody = $@"Hey !
    
You got a new customer feedback, customer details are:
Name: {emailObj.name} 
Email: {emailObj.email}
Phone: {emailObj.phone}

Feedback: 

'{emailObj.message}'
        

                    
                ";
                    builder.Attachments.Add(@$"{System.IO.Directory.GetCurrentDirectory()}/Resources/logo.png");
                    email.Body = builder.ToMessageBody();
                    using var smtp = new SmtpClient();
                    smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
                    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);

                    return true;
                }

                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;
        }

            public async Task<bool> sendNewOrderEmail(OrderEmailModel emailObj)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            if (emailObj.emailRecipients.Count > 0)
            {
                foreach (var emailAddress in emailObj.emailRecipients)
                {
                    email.To.Add(MailboxAddress.Parse(emailAddress));
                }

                email.Subject = emailObj.subject;
                var builder = new BodyBuilder();

                try
                {
                    //builder.HtmlBody = mailRequest.Body;

                    //verbatim string is created using a special symbol @
                    //don't change text spacing
                    builder.TextBody = $@"Congratulations,
    
You got a new order, details are:
Name: {emailObj.firstName} {emailObj.lastName}
City: {emailObj.city}
Amount: {emailObj.gtotal}

Start Preparing it today!
        
Thanks
                    
                ";
                    builder.Attachments.Add(@$"{System.IO.Directory.GetCurrentDirectory()}/Resources/logo.png");
                    email.Body = builder.ToMessageBody();
                    using var smtp = new SmtpClient();
                    smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
                    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);

                    return true;
                }
                
                catch (Exception e)
                {
                    throw e;
                }
            }
            return false;

        }


    }
}
