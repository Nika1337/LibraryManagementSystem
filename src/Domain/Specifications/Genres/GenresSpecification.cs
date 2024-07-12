using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Genres;

public class GenresSpecification : BaseModelSpecification<Genre>
{
    protected override Expression<Func<Genre, string>>[] FieldSelectors => [genre => genre.Name, genre => genre.Description];

    public GenresSpecification(BaseModelSpecificationParameters<Genre> parameters) : base(parameters)
    {

    }
}
