using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class AuthorService : BaseModelService<Author>, IAuthorService
{
    private readonly IMapper _mapper;

    public AuthorService(
        IRepository<Author> repository,
        IMapper mapper) : base(repository)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorResponse>> GetAuthorsAsync()
    {
        var authors = await _repository.ListAsync();

        var response = _mapper.Map<IEnumerable<AuthorResponse>>(authors);

        return response;
    }

    public async Task<AuthorResponse> GetAuthorAsync(int id)
    {
        var author = await GetEntityAsync(id);

        var response = _mapper.Map<AuthorResponse>(author);

        return response;
    }

    public async Task CreateAuthorAsync(AuthorCreateRequest request)
    {

        var author = _mapper.Map<Author>(request);

        await _repository.AddAsync(author);
    }

    public async Task UpdateAuthorAsync(AuthorUpdateRequest request)
    {

        var author = await GetEntityAsync(request.Id);

        _mapper.Map(request, author);

        await _repository.UpdateAsync(author);
    }
}