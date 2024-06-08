﻿using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IEmailTemplateService
{
    Task<IEnumerable<EmailTemplate>> GetAllActiveEmailTemplatesAsync();
    Task<EmailTemplate> GetEmailTemplateAsync(int templateId);
    Task UpdateEmailTemplateAsync(EmailTemplate emailTemplate);
    Task DeleteEmailTemplateAsync(int templateId);
    Task RenewEmailTemplateAsync(int templateId);
}
