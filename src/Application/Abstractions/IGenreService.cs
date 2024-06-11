

using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IGenreService
{
    Task<IEnumerable<GenreResponse>> GetGenresAsync();
    Task<GenreResponse> GetGenreAsync(int id);
    Task AddGenreAsync(GenreCreateRequest request);

    Task UpdateGenreAsync(GenreUpdateRequest request);

    Task DeleteGenreAsync(int id);

    Task RenewGenreAsync(int id);
}
