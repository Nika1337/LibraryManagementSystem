using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using Nika1337.Library.Application.Specifications;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class GenreService : IGenreService
{
    private readonly IRepository<Genre> _repository;
    private readonly IMapper _mapper;

    public GenreService(
        IRepository<Genre> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenreResponse>> GetGenresAsync()
    {
        var genres = await _repository.ListAsync();

        var response = _mapper.Map<IEnumerable<GenreResponse>>(genres);

        return response;
    }

    public async Task<GenreResponse> GetGenreAsync(int id)
    {
        var genre = await GetGenreEntityAsync(id);

        var response = _mapper.Map<GenreResponse>(genre);

        return response;
    }

    public async Task CreateGenreAsync(GenreCreateRequest request)
    {
        await ThrowIfNameExistsAsync(request.Name);

        var genre = _mapper.Map<Genre>(request);

        await _repository.AddAsync(genre);
    }

    public async Task UpdateGenreAsync(GenreUpdateRequest request)
    {
        await ThrowIfGenreWithGivenNameHasDifferentIdAsync(request.Name, request.Id);

        var genre = await GetGenreEntityAsync(request.Id);

        _mapper.Map(request, genre);

        await _repository.UpdateAsync(genre);
    }

    public async Task DeleteGenreAsync(int id)
    {
        var genre = await GetGenreEntityAsync(id);

        genre.Delete();

        await _repository.UpdateAsync(genre);
    }

    public async Task RenewGenreAsync(int id)
    {
        var genre = await GetGenreEntityAsync(id);

        genre.Renew();

        await _repository.UpdateAsync(genre);
    }



    private async Task<Genre> GetGenreEntityAsync(int id)
    {
        var genre = await _repository.GetByIdAsync(id) ?? throw new GenreNotFoundException(id);

        return genre;
    }

    private async Task ThrowIfNameExistsAsync(string name)
    {
        var specification = new GenreSpecification(name);

        var isNameUsed = await _repository.AnyAsync(specification);

        if (isNameUsed)
        {
            throw new NameDuplicateException($"Genre with name '{name}' already exists");
        }
    }

    private async Task ThrowIfGenreWithGivenNameHasDifferentIdAsync(string name, int id)
    {
        var specification = new GenreSpecification(name, id);

        var isNameUsedByDifferentEntity = await _repository.AnyAsync(specification);

        if (isNameUsedByDifferentEntity)
        {
            throw new NameDuplicateException($"Genre with name '{name}' already exists");
        }
    }
}