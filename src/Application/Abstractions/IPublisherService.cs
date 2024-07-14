

using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Publishers;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IPublisherService : IBaseModelService
{
    Task<IEnumerable<PublisherPrimitiveResponse>> GetActivePublishersAsync();
    Task<PagedList<PublisherPreviewResponse>> GetPagedPublishersAsync(BaseModelPagedRequest<Publisher> request);
    Task<PublisherDetailedResponse> GetPublisherAsync(int id);
    Task CreatePublisherAsync(PublisherCreateRequest request);
    Task UpdatePublisherAsync(PublisherUpdateRequest request);
}
