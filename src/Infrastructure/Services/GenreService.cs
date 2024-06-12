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

internal class GenreService : CRUDService<Genre>, IGenreService
{

    public GenreService(
        IRepository<Genre> repository,
        IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<GenreResponse>> GetGenresAsync() => await GetAllAsync<GenreResponse>();

    public async Task<GenreResponse> GetGenreAsync(int id) => await GetAsync<GenreResponse>(id);
    
    public async Task CreateGenreAsync(GenreCreateRequest request) => await CreateAsync(request, request => request.Name);

    public async Task UpdateGenreAsync(GenreUpdateRequest request) => await UpdateAsync(request, request => request.Id, request => request.Name);

    public async Task DeleteGenreAsync(int id) => await DeleteAsync(id);
    public async Task RenewGenreAsync(int id) => await RenewAsync(id);


    protected override async Task ThrowIfNameExistsAsync(string name)
    {
        var specification = new GenreSpecification(name);

        var isNameUsed = await _repository.AnyAsync(specification);

        if (isNameUsed)
        {
            throw new NameDuplicateException($"Genre with name '{name}' already exists");
        }
    }

    protected override async Task ThrowIfEntityWithGivenNameHasDifferentId(string name, int id)
    {
        var specification = new GenreSpecification(name, id);

        var isNameUsedByDifferentEntity = await _repository.AnyAsync(specification);

        if (isNameUsedByDifferentEntity)
        {
            throw new NameDuplicateException($"Genre with name '{name}' already exists");
        }
    }
}
