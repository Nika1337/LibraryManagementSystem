using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Services;

public class EmailTemplateService : IEmailTemplateService
{
    private readonly IRepository<EmailTemplate> _repository;

    public EmailTemplateService(IRepository<EmailTemplate> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmailTemplate>> GetAllEmailTemplatesAsync()
    {
        return await _repository.ListAsync();
    }

    public async Task<EmailTemplate> GetEmailTemplateAsync(int templateId)
    {
        var specification = new EmailTemplateByIdSpecification(templateId);

        var emailTemplate = await _repository.SingleOrDefaultAsync(specification) ?? throw new EmailTemplateNotFoundException(templateId);

        return emailTemplate;
    }
    public async Task UpdateEmailTemplateAsync(EmailTemplate template)
    {
        var specification = new EmailTemplateByIdSpecification(template.Id);

        var doesTemplateExist = await _repository.AnyAsync(specification);

        if (!doesTemplateExist)
        {
            throw new EmailTemplateNotFoundException(template.Id);
        }

        await _repository.UpdateAsync(template);
    }
    public async Task DeleteEmailTemplateAsync(int templateId)
    {
        var emailTemplate = await GetEmailTemplateAsync(templateId);

        emailTemplate.DeletedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(emailTemplate);
    }

    public async Task RenewEmailTemplateAsync(int templateId)
    {
        var emailTemplate = await GetEmailTemplateAsync(templateId);

        emailTemplate.DeletedDate = null;

        await _repository.UpdateAsync(emailTemplate);
    }
}
