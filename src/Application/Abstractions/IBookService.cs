

using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IBookService : IBaseModelService
{
    Task<IEnumerable<BookPreviewResponse>> GetBooksAsync();
    Task<BookDetailedResponse> GetBookAsync(int id);
    Task CreateBookAsync(BookCreateRequest request);
    Task UpdateBookAsync(BookUpdateRequest request);
}
