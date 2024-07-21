

using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IBookService : IBaseModelService
{
    Task<IEnumerable<PrimitiveResponse>> GetAvaliableBooksAsync();
    Task<PagedList<BookPreviewResponse>> GetPagedBooksAsync(BaseModelPagedRequest<Book> request);
    Task<BookDetailedResponse> GetBookAsync(int id);
    Task CreateBookAsync(BookCreateRequest request);
    Task UpdateBookAsync(BookUpdateRequest request);
}
