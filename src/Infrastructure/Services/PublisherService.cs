

using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Publishers;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications;
using Nika1337.Library.Domain.Specifications.Publishers;
using Nika1337.Library.Domain.Specifications.Publishers.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class PublisherService : BaseModelService<Publisher>, IPublisherService
{
    private readonly IMapper _mapper;

    public PublisherService(
        IRepository<Publisher> repository,
        IMapper mapper) : base(repository)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<PrimitiveResponse>> GetActivePublishersAsync()
    {
        var specification = new NonDeletedSpecification<Publisher>();

        var publishers = await _repository.ListAsync(specification);

        var response = _mapper.Map<IEnumerable<PrimitiveResponse>>(publishers);

        return response;
    }

    public async Task<PagedList<PublisherPreviewResponse>> GetPagedPublishersAsync(BaseModelPagedRequest<Publisher> request)
    {
        var specificationParameters = _mapper.Map<BaseModelSpecificationParameters<Publisher>>(request);

        var specification = new PublishersSpecification(specificationParameters);

        var publishers = await _repository.PagedListAsync(specification, request.PageNumber, request.PageSize);

        var response = _mapper.Map<PagedList<PublisherPreviewResponse>>(publishers);

        return response;
    }

    public async Task<PublisherDetailedResponse> GetPublisherAsync(int id)
    {
        var publisher = await GetDetailedPublisherAsync(id);

        var response = _mapper.Map<PublisherDetailedResponse>(publisher);

        return response;
    }

    public async Task CreatePublisherAsync(PublisherCreateRequest request)
    {
        await ThrowIfPublisherNameExistsAsync(request.PublisherName);

        var publisher = _mapper.Map<Publisher>(request);

        await _repository.AddAsync(publisher);
    }

    public async Task UpdatePublisherAsync(PublisherUpdateRequest request)
    {
        await ThrowIfPublisherWithGivenNameHasDifferentIdAsync(request.PublisherName, request.Id);

        var publisher = await GetEntityAsync(request.Id);

        _mapper.Map(request, publisher);

        await _repository.UpdateAsync(publisher);
    }

    private async Task<PublisherDetailedResult> GetDetailedPublisherAsync(int id)
    {
        var specification = new PublisherDetailedSpecification(id);

        var publisher = await _repository.SingleOrDefaultAsync(specification) ?? throw new NotFoundException<Publisher>(id);

        return publisher;
    }

    private async Task ThrowIfPublisherNameExistsAsync(string name)
    {
        var specification = new PublisherByNameSpecification(name);

        var isNameUsed = await _repository.AnyAsync(specification);

        if (isNameUsed)
        {
            throw new NameDuplicateException($"Publisher with name '{name}' already exists");
        }
    }

    private async Task ThrowIfPublisherWithGivenNameHasDifferentIdAsync(string name, int id)
    {
        var specification = new PublisherByNameSpecification(name);

        var publisher = await _repository.SingleOrDefaultAsync(specification);

        var isNameUsedByDifferentPublisher = publisher is not null && publisher.Id != id;

        if (isNameUsedByDifferentPublisher)
        {
            throw new NameDuplicateException($"Publisher with name '{name}' already exists");
        }
    }
}
