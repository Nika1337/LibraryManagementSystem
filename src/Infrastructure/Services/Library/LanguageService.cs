using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using Nika1337.Library.Application.Specifications;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class LanguageService : CRUDService<Language>, ILanguageService
{

    public LanguageService(
        IRepository<Language> repository,
        IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<LanguageResponse>> GetLanguagesAsync() => await GetAllAsync<LanguageResponse>();

    public async Task<LanguageResponse> GetLanguageAsync(int id) => await GetAsync<LanguageResponse>(id);

    public async Task CreateLanguageAsync(LanguageCreateRequest request) => await CreateAsync(request, request => request.Name);

    public async Task UpdateLanguageAsync(LanguageUpdateRequest request) => await UpdateAsync(request, request => request.Id, request => request.Name);

    public async Task DeleteLanguageAsync(int id) => await DeleteAsync(id);
    public async Task RenewLanguageAsync(int id) => await RenewAsync(id);


    protected override async Task ThrowIfNameExistsAsync(string name)
    {
        var specification = new LanguageSpecification(name);

        var isNameUsed = await _repository.AnyAsync(specification);

        if (isNameUsed)
        {
            throw new NameDuplicateException($"Language with name '{name}' already exists");
        }
    }

    protected override async Task ThrowIfEntityWithGivenNameHasDifferentId(string name, int id)
    {
        var specification = new LanguageSpecification(name, id);

        var isNameUsedByDifferentEntity = await _repository.AnyAsync(specification);

        if (isNameUsedByDifferentEntity)
        {
            throw new NameDuplicateException($"Language with name '{name}' already exists");
        }
    }
}
