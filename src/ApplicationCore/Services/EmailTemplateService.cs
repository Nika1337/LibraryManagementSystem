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

    public async Task<IEnumerable<EmailTemplate>> GetAllActiveEmailTemplatesAsync()
    {
        return await _repository.ListAsync();
    }

    public async Task<EmailTemplate> GetEmailTemplateByIdAsync(int templateId)
    {
        var specification = new EmailTemplateByNameOrIdSpecification(templateId);

        var emailTemplate = await _repository.SingleOrDefaultAsync(specification) ?? throw new EmailTemplateNotFoundException(templateId);

        return emailTemplate;
    }

    public async Task<EmailTemplate> GetEmailTemplateByNameAsync(string templateName)
    {
        var specification = new EmailTemplateByNameOrIdSpecification(templateName);

        var emailTemplate = await _repository.SingleOrDefaultAsync(specification) ?? throw new EmailTemplateNotFoundException(templateName);

        return emailTemplate;
    }

    public async Task UpdateEmailTemplateAsync(EmailTemplate emailTemplate)
    {
        var specification = new EmailTemplateByNameOrIdSpecification(emailTemplate.Name);

        var existingTemplatesWithSameName = await _repository.SingleOrDefaultAsync(specification);

        if (existingTemplatesWithSameName is not null && existingTemplatesWithSameName.Id != emailTemplate.Id)
        {
            throw new DuplicateException($"Email template with name '{emailTemplate.Name}' already exists");
        }


        emailTemplate.LastUpdatedDate = DateTime.UtcNow;
        await _repository.UpdateAsync(emailTemplate);
    }
    public async Task DeleteEmailTemplateAsync(int templateId)
    {
        var emailTemplate = await GetEmailTemplateByIdAsync(templateId);

        emailTemplate.DeletedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(emailTemplate);
    }

    public async Task RenewEmailTemplateAsync(int templateId)
    {
        var emailTemplate = await GetEmailTemplateByIdAsync(templateId);

        emailTemplate.DeletedDate = null;

        await _repository.UpdateAsync(emailTemplate);
    }
}
