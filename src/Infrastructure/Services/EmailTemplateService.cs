using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
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
    private readonly IMapper _mapper;
    public EmailTemplateService(
        IRepository<EmailTemplate> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmailTemplateSimpleResponse>> GetAllEmailTemplatesAsync()
    {
        var templates = await _repository.ListAsync();

        var response = _mapper.Map<IEnumerable<EmailTemplateSimpleResponse>>(templates);

        return response;
    }

    public async Task<EmailTemplateDetailedResponse> GetEmailTemplateAsync(int id)
    {
        var template = await GetEmailTemplateEntityAsync(id);

        var response = _mapper.Map<EmailTemplateDetailedResponse>(template);

        return response;
    }
    public async Task UpdateEmailTemplateAsync(EmailTemplateUpdateRequest templateUpdateRequest)
    {
        var template = await GetEmailTemplateEntityAsync(templateUpdateRequest.Id);

        _mapper.Map(templateUpdateRequest, template);

        await _repository.UpdateAsync(template);
    }
    public async Task DeleteEmailTemplateAsync(int id)
    {
        var template = await GetEmailTemplateEntityAsync(id);

        template.DeletedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(template);
    }

    public async Task RenewEmailTemplateAsync(int id)
    {
        var template = await GetEmailTemplateEntityAsync(id);

        template.DeletedDate = null;

        await _repository.UpdateAsync(template);
    }

    private async Task<EmailTemplate> GetEmailTemplateEntityAsync(int id)
    {
        var specification = new EmailTemplateByIdSpecification(id);

        var emailTemplate = await _repository.SingleOrDefaultAsync(specification) ?? throw new EmailTemplateNotFoundException(id);

        return emailTemplate;
    }
}
