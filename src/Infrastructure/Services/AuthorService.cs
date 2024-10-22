﻿using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications;
using Nika1337.Library.Domain.Specifications.Authors;
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

    public async Task<PagedList<AuthorPreviewResponse>> GetPagedAuthorsAsync(BaseModelPagedRequest<Author> request)
    {
        var specificationParameters = _mapper.Map<BaseModelSpecificationParameters<Author>>(request);

        var specification = new AuthorsSpecification(specificationParameters);

        var authors = await _repository.PagedListAsync(specification, request.PageNumber, request.PageSize);

        var result = _mapper.Map<PagedList<AuthorPreviewResponse>>(authors);

        return result;
    }

    public async Task<IEnumerable<PrimitiveResponse>> GetActiveAuthorsAsync()
    {
        var specification = new NonDeletedSpecification<Author>();

        var authors = await _repository.ListAsync(specification);

        var response = _mapper.Map<IEnumerable<PrimitiveResponse>>(authors);

        return response;
    }

    public async Task<AuthorDetailedResponse> GetAuthorAsync(int id)
    {
        var specification = new AuthorDetailedSpecification(id);

        var author = await _repository.SingleOrDefaultAsync(specification);

        var response = _mapper.Map<AuthorDetailedResponse>(author);

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