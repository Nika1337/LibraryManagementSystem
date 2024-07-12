using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.Specifications.EmailTemplates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class EmailTemplateService : BaseModelService<EmailTemplate>, IEmailTemplateService
{
    private readonly IMapper _mapper;
    public EmailTemplateService(
        IRepository<EmailTemplate> repository,
        IMapper mapper) : base(repository)
    {
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
        var template = await GetEntityAsync(id);

        var response = _mapper.Map<EmailTemplateDetailedResponse>(template);

        return response;
    }
    public async Task UpdateEmailTemplateAsync(EmailTemplateUpdateRequest templateUpdateRequest)
    {
        var template = await GetEntityAsync(templateUpdateRequest.Id);

        await ThrowIfTemplateWithGivenNameHasDifferentId(templateUpdateRequest.Name, templateUpdateRequest.Id);

        _mapper.Map(templateUpdateRequest, template);

        await _repository.UpdateAsync(template);
    }

    private async Task ThrowIfTemplateWithGivenNameHasDifferentId(string name, int id)
    {
        var specification = new EmailTemplateByNameSpecification(name);

        var template = await _repository.SingleOrDefaultAsync(specification);

        var isNameUsedByDifferentEntity = template is not null && template.Id != id;

        if (isNameUsedByDifferentEntity)
        {
            throw new NameDuplicateException($"Email Template with name '{name}' already exists");
        }
    }
}
