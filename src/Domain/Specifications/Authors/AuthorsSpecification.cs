

using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Authors;

public class AuthorsSpecification : BaseModelSpecification<Author>
{
    protected override Expression<Func<Author, string>>[] FieldSelectors => [author => author.Biography, author => author.Name];

    public AuthorsSpecification(BaseModelSpecificationParameters<Author> parameters) : base(parameters)
    {

    }
}
