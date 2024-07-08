using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications;
using Nika1337.Library.Domain.Specifications.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class GenreService : BaseModelService<Genre>, IGenreService
{
    private readonly IMapper _mapper;

    public GenreService(
        IRepository<Genre> repository,
        IMapper mapper) : base(repository)
    {
        _mapper = mapper;
    }

    public async Task<PagedList<GenreResponse>> GetPagedGenresAsync(BaseModelPagedRequest<Genre> request)
    {
        var specificationParameters = _mapper.Map<BaseModelSpecificationParameters<Genre>>(request);

        var specification = new GenrePagedSpecification(specificationParameters);


        var genres = await _repository.PagedListAsync(specification, request.PageNumber, request.PageSize);

        var result = _mapper.Map<PagedList<GenreResponse>>(genres);

        return result;
    }

    public async Task<IEnumerable<GenrePreviewResponse>> GetActiveGenrePreviewsAsync()
    {
        var specification = new NonDeletedSpecification<Genre>();

        var genres = await _repository.ListAsync(specification);

        var response = _mapper.Map<IEnumerable<GenrePreviewResponse>>(genres);

        return response;
    }


    public async Task<GenreResponse> GetGenreAsync(int id)
    {
        var genre = await GetEntityAsync(id);

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

        var genre = await GetEntityAsync(request.Id);

        _mapper.Map(request, genre);

        await _repository.UpdateAsync(genre);
    }

    private async Task ThrowIfNameExistsAsync(string name)
    {
        var specification = new GenreWithNameSpecification(name);

        var isNameUsed = await _repository.AnyAsync(specification);

        if (isNameUsed)
        {
            throw new NameDuplicateException($"Genre with name '{name}' already exists");
        }
    }

    private async Task ThrowIfGenreWithGivenNameHasDifferentIdAsync(string name, int id)
    {
        var specification = new GenreWithNameSpecification(name);

        var genre = await _repository.SingleOrDefaultAsync(specification);

        var isNameUsedByDifferentGenre = genre is not null && genre.Id != id;

        if (isNameUsedByDifferentGenre)
        {
            throw new NameDuplicateException($"Genre with name '{name}' already exists");
        }
    }
}