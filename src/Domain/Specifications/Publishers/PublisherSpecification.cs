
using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Publishers;

public class PublisherSpecification : BaseModelSpecification<Publisher>
{
    protected override Expression<Func<Publisher, string>>[] FieldSelectors =>
    [
        publisher => publisher.PublisherName,
        publisher => publisher.ContactInformation.Email,
        publisher => publisher.ContactInformation.PhoneNumber,
    ];

    public PublisherSpecification(BaseModelSpecificationParameters<Publisher> parameters) : base(parameters)
    {
        Query.Include(publisher => publisher.PublishedBookEditions);
    }
}
