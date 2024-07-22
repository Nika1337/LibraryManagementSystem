

using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.BookEditions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IBookEditionService : IBaseModelService
{
    Task<IEnumerable<PrimitiveResponse>> GetAvaliableBookEditionsAsync(int bookId);
    Task<PagedList<BookEditionPreviewResponse>> GetPagedBookEditionsAsync(int bookId, BaseModelPagedRequest<BookEdition> request);
    Task<BookEditionDetailedResponse> GetBookEditionAsync(int bookId, int id);
    Task CreateBookEditionAsync(int bookId, BookEditionCreateRequest request);
    Task UpdateBookEditionAsync(int bookId, BookEditionUpdateRequest request);
}
