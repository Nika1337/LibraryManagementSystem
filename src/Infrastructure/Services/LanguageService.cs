using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications;
using Nika1337.Library.Domain.Specifications.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class LanguageService : BaseModelService<Language>, ILanguageService
{
    private readonly IMapper _mapper;

    public LanguageService(
        IRepository<Language> repository,
        IMapper mapper) : base(repository)
    {
        _mapper = mapper;
    }

    public async Task<PagedList<LanguagePreviewResponse>> GetPagedLanguagesAsync(BaseModelPagedRequest<Language> request)
    {
        var specificationParameters = _mapper.Map<BaseModelSpecificationParameters<Language>>(request);

        var specification = new LanguagesSpecification(specificationParameters);


        var languages = await _repository.PagedListAsync(specification, request.PageNumber, request.PageSize);

        var result = _mapper.Map<PagedList<LanguagePreviewResponse>>(languages);

        return result;
    }

    public async Task<IEnumerable<PrimitiveResponse>> GetActiveLanguagesAsync()
    {
        var specification = new NonDeletedSpecification<Language>();

        var genres = await _repository.ListAsync(specification);

        var response = _mapper.Map<IEnumerable<PrimitiveResponse>>(genres);

        return response;
    }

    public async Task<LanguageDetailedResponse> GetLanguageAsync(int id)
    {
        var specification = new LanguageDetailedSpecification(id);

        var language = await _repository.SingleOrDefaultAsync(specification) ?? throw new NotFoundException<Language>(id);

        var response = _mapper.Map<LanguageDetailedResponse>(language);

        return response;
    }

    public async Task CreateLanguageAsync(LanguageCreateRequest request)
    {
        await ThrowIfNameExistsAsync(request.Name);

        var language = _mapper.Map<Language>(request);

        await _repository.AddAsync(language);
    }

    public async Task UpdateLanguageAsync(LanguageUpdateRequest request)
    {
        await ThrowIfLanguageWithGivenNameHasDifferentIdAsync(request.Name, request.Id);

        var language = await GetEntityAsync(request.Id);

        _mapper.Map(request, language);

        await _repository.UpdateAsync(language);
    }

    public async Task DeleteLanguageAsync(int id)
    {
        var language = await GetEntityAsync(id);

        language.Delete();

        await _repository.UpdateAsync(language);
    }

    public async Task RenewLanguageAsync(int id)
    {
        var language = await GetEntityAsync(id);

        language.Renew();

        await _repository.UpdateAsync(language);
    }


    private async Task ThrowIfNameExistsAsync(string name)
    {
        var specification = new LanguageByNameSpecification(name);

        var isNameUsed = await _repository.AnyAsync(specification);

        if (isNameUsed)
        {
            throw new NameDuplicateException($"Language with name '{name}' already exists");
        }
    }

    private async Task ThrowIfLanguageWithGivenNameHasDifferentIdAsync(string name, int id)
    {
        var specification = new LanguageByNameSpecification(name);

        var language = await _repository.SingleOrDefaultAsync(specification);

        var isNameUsedByDifferentEntity = language is not null && language.Id != id;

        if (isNameUsedByDifferentEntity)
        {
            throw new NameDuplicateException($"Language with name '{name}' already exists");
        }
    }
}