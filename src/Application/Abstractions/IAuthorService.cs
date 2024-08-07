
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IAuthorService : IBaseModelService
{
    Task<PagedList<AuthorPreviewResponse>> GetPagedAuthorsAsync(BaseModelPagedRequest<Author> request);
    Task<IEnumerable<PrimitiveResponse>> GetActiveAuthorsAsync();
    Task<AuthorDetailedResponse> GetAuthorAsync(int id);
    Task CreateAuthorAsync(AuthorCreateRequest request);
    Task UpdateAuthorAsync(AuthorUpdateRequest request);
}
