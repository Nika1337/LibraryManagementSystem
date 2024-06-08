using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IEmailSender
{
    Task SendEmailAsync(string fromEmail, string toEmail, string subject, string body);
}
