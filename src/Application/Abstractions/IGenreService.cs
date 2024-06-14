

using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IGenreService : IBaseModelService
{
    Task<IEnumerable<GenreResponse>> GetGenresAsync();
    Task<GenreResponse> GetGenreAsync(int id);
    Task CreateGenreAsync(GenreCreateRequest request);
    Task UpdateGenreAsync(GenreUpdateRequest request);
}
