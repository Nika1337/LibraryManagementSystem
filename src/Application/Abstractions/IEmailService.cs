

using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IEmailService
{
    public Task SendEmailAsync(string toEmail, int templateId, object templateContent);
}
