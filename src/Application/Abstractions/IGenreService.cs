

using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IGenreService : IBaseModelService
{
    Task<PagedList<GenrePreviewResponse>> GetPagedGenresAsync(BaseModelPagedRequest<Genre> request);
    Task<IEnumerable<PrimitiveResponse>> GetActiveGenresAsync();
    Task<GenreDetailedResponse> GetGenreAsync(int id);
    Task CreateGenreAsync(GenreCreateRequest request);
    Task UpdateGenreAsync(GenreUpdateRequest request);
}
