using System.Threading.Tasks;

namespace NetCoreSaaS.WebHost.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
