using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Genres.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Genres;

public class GenreDetailedSpecification : BaseModelByIdSpecification<Genre, GenreDetailedResult>
{
    public GenreDetailedSpecification(int id) : base(id)
    {
        Query.Select(genre => new GenreDetailedResult
        {
            Id = genre.Id,
            Name = genre.Name,
            Description = genre.Description,
            DeletedDate = genre.DeletedDate
        });
    }
}