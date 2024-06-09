using Nika1337.Library.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IEmailTemplateService
{
    Task<IEnumerable<EmailTemplateSimpleResponse>> GetAllEmailTemplatesAsync();
    Task<EmailTemplateDetailedResponse> GetEmailTemplateAsync(int templateId);
    Task UpdateEmailTemplateAsync(EmailTemplateUpdateRequest emailTemplate);
    Task DeleteEmailTemplateAsync(int templateId);
    Task RenewEmailTemplateAsync(int templateId);
}
