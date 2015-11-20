using DMS.SharedKernel.Infrastructure.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace DMS.SharedKernel.Infrastructure.EmailService
{
    public class SMTPService : IEmailService
    {
        public void SendMail(string from, string to, string subject, string body)
        {

            MailMessage message = new MailMessage();

            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;
            
            string userName = ApplicationSettingsFactory.GetApplicationSettings().EmailAddress;
            string password = ApplicationSettingsFactory.GetApplicationSettings().Credential;
            //string userName = "mojamcpds@gmail.com";
            //string password = "@lgo123321";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            smtp.Credentials = new NetworkCredential(userName, password);
            smtp.EnableSsl = true;
            smtp.Send(message);

        }
    }

}
