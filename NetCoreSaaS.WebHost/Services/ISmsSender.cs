using System.Threading.Tasks;

namespace NetCoreSaaS.WebHost.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
