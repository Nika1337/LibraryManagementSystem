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

internal class LanguageService : ILanguageService
{
    private readonly IRepository<Language> _repository;
    private readonly IMapper _mapper;

    public LanguageService(
        IRepository<Language> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LanguageResponse>> GetLanguagesAsync()
    {
        var genres = await _repository.ListAsync();

        var response = _mapper.Map<IEnumerable<LanguageResponse>>(genres);

        return response;
    }

    public async Task<LanguageResponse> GetLanguageAsync(int id)
    {
        var genre = await GetLanguageEntityAsync(id);

        var response = _mapper.Map<LanguageResponse>(genre);

        return response;
    }

    public async Task CreateLanguageAsync(LanguageCreateRequest request)
    {
        await ThrowIfNameExistsAsync(request.Name);

        var genre = _mapper.Map<Language>(request);

        await _repository.AddAsync(genre);
    }

    public async Task UpdateLanguageAsync(LanguageUpdateRequest request)
    {
        await ThrowIfLanguageWithGivenNameHasDifferentIdAsync(request.Name, request.Id);

        var genre = await GetLanguageEntityAsync(request.Id);

        _mapper.Map(request, genre);

        await _repository.UpdateAsync(genre);
    }

    public async Task DeleteLanguageAsync(int id)
    {
        var genre = await GetLanguageEntityAsync(id);

        genre.Delete();

        await _repository.UpdateAsync(genre);
    }

    public async Task RenewLanguageAsync(int id)
    {
        var genre = await GetLanguageEntityAsync(id);

        genre.Renew();

        await _repository.UpdateAsync(genre);
    }



    private async Task<Language> GetLanguageEntityAsync(int id)
    {
        var genre = await _repository.GetByIdAsync(id) ?? throw new LanguageNotFoundException(id);

        return genre;
    }

    private async Task ThrowIfNameExistsAsync(string name)
    {
        var specification = new LanguageSpecification(name);

        var isNameUsed = await _repository.AnyAsync(specification);

        if (isNameUsed)
        {
            throw new NameDuplicateException($"Language with name '{name}' already exists");
        }
    }

    private async Task ThrowIfLanguageWithGivenNameHasDifferentIdAsync(string name, int id)
    {
        var specification = new LanguageSpecification(name, id);

        var isNameUsedByDifferentEntity = await _repository.AnyAsync(specification);

        if (isNameUsedByDifferentEntity)
        {
            throw new NameDuplicateException($"Language with name '{name}' already exists");
        }
    }
}