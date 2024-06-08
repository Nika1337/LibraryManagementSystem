

using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IEmailService
{
    public Task SendEmailAsync(string toEmail, int templateId, object templateContent);
}
