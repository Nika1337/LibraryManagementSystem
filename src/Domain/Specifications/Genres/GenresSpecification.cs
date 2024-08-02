using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.Genres.Results;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Genres;

public class GenresSpecification : BaseModelSpecification<Genre, GenreResult>
{
    protected override Expression<Func<Genre, string>>[] FieldSelectors => [genre => genre.Name, genre => genre.Description];

    public GenresSpecification(BaseModelSpecificationParameters<Genre> parameters) : base(parameters)
    {
        Query.Select(g => new GenreResult
        {
            Id = g.Id,
            Name = g.Name,
            Description = g.Description,
            IsActive = g.DeletedDate == null
        });
    }
}
