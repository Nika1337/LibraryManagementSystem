

using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Authors;

public class AuthorPagedSpecification : BaseModelSpecification<Author>
{
    protected override Expression<Func<Author, string>>[] FieldSelectors => [author => author.Biography, author => author.Name];

    public AuthorPagedSpecification(BaseModelSpecificationParameters<Author> parameters) : base(parameters)
    {

    }
}
