
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IAuthorService : IBaseModelService
{
    Task<IEnumerable<AuthorResponse>> GetAuthorsAsync();
    Task<IEnumerable<AuthorPreviewResponse>> GetActiveAuthorPreviewsAsync();
    Task<AuthorResponse> GetAuthorAsync(int id);
    Task CreateAuthorAsync(AuthorCreateRequest request);
    Task UpdateAuthorAsync(AuthorUpdateRequest request);
}
