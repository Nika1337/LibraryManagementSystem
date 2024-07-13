

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Bookshelves;

public class BookshelfSpecification : BaseModelSpecification<Bookshelf>
{
    protected override Expression<Func<Bookshelf, string>>[] FieldSelectors => [];

    public BookshelfSpecification(BaseModelSpecificationParameters<Bookshelf> parameters) : base(parameters)
    {
        Query.Include(bookshelf => bookshelf.Shelves);
    }

}
