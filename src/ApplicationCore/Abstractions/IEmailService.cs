

using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IEmailService
{
    public Task SendEmailAsync(string toEmail, string templateName, object templateContent);
}
