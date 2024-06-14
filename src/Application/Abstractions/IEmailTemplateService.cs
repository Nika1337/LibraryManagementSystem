using Nika1337.Library.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IEmailTemplateService : IBaseModelService
{
    Task<IEnumerable<EmailTemplateSimpleResponse>> GetAllEmailTemplatesAsync();
    Task<EmailTemplateDetailedResponse> GetEmailTemplateAsync(int templateId);
    Task UpdateEmailTemplateAsync(EmailTemplateUpdateRequest emailTemplate);
}
