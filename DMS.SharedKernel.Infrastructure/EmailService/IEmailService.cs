namespace DMS.SharedKernel.Infrastructure.EmailService
{
    public interface IEmailService
    {
        void SendMail(string from, string to, string subject, string body);
    }
}
