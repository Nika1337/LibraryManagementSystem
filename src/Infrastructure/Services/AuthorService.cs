using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class AuthorService : IAuthorService
{
    private readonly IRepository<Author> _repository;
    private readonly IMapper _mapper;

    public AuthorService(
        IRepository<Author> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorResponse>> GetAuthorsAsync()
    {
        var genres = await _repository.ListAsync();

        var response = _mapper.Map<IEnumerable<AuthorResponse>>(genres);

        return response;
    }

    public async Task<AuthorResponse> GetAuthorAsync(int id)
    {
        var genre = await GetAuthorEntityAsync(id);

        var response = _mapper.Map<AuthorResponse>(genre);

        return response;
    }

    public async Task CreateAuthorAsync(AuthorCreateRequest request)
    {

        var genre = _mapper.Map<Author>(request);

        await _repository.AddAsync(genre);
    }

    public async Task UpdateAuthorAsync(AuthorUpdateRequest request)
    {

        var genre = await GetAuthorEntityAsync(request.Id);

        _mapper.Map(request, genre);

        await _repository.UpdateAsync(genre);
    }

    public async Task DeleteAuthorAsync(int id)
    {
        var genre = await GetAuthorEntityAsync(id);

        genre.Delete();

        await _repository.UpdateAsync(genre);
    }

    public async Task RenewAuthorAsync(int id)
    {
        var genre = await GetAuthorEntityAsync(id);

        genre.Renew();

        await _repository.UpdateAsync(genre);
    }



    private async Task<Author> GetAuthorEntityAsync(int id)
    {
        var genre = await _repository.GetByIdAsync(id) ?? throw new AuthorNotFoundException(id);

        return genre;
    }
}