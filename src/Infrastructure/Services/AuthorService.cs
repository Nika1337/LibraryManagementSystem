using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications;
using Nika1337.Library.Domain.Specifications.Authors;
using Nika1337.Library.Domain.Specifications.Books;
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

    public async Task<PagedList<AuthorResponse>> GetPagedAuthorsAsync(PagedRequest<Author> request)
    {
        var specificationParameters = _mapper.Map<BaseModelSpecificationParameters<Author>>(request);

        var specification = new AuthorPagedSpecification(specificationParameters);

        var authors = await _repository.PagedListAsync(specification, request.PageNumber, request.PageSize);

        var result = _mapper.Map<PagedList<AuthorResponse>>(authors);

        return result;
    }

    public async Task<IEnumerable<AuthorPreviewResponse>> GetActiveAuthorPreviewsAsync()
    {
        var specification = new NonDeletedSpecification<Author>();

        var authors = await _repository.ListAsync(specification);

        var response = _mapper.Map<IEnumerable<AuthorPreviewResponse>>(authors);

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