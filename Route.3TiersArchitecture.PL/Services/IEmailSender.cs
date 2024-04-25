using System.Threading.Tasks;

namespace Route._3TiersArchitecture.PL.Services
{
    public interface IEmailSender
    {
        Task SendAsync(string from, string recipiens, string subject, string body);
    }
}