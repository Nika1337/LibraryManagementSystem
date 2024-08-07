
using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.Publishers.Results;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Publishers;

public class PublishersSpecification : BaseModelsSpecification<Publisher, PublisherResult>
{
    protected override Expression<Func<Publisher, string>>[] FieldSelectors =>
    [
        publisher => publisher.PublisherName,
        publisher => publisher.ContactInformation.Email,
        publisher => publisher.ContactInformation.PhoneNumber,
    ];

    public PublishersSpecification(BaseModelSpecificationParameters<Publisher> parameters) : base(parameters)
    {
        Query.Select(publisher => new PublisherResult
        {
            Id = publisher.Id,
            PublisherName = publisher.PublisherName,
            WebsiteAddress = publisher.WebsiteAddress,
            PublishedBookEditionsCount = publisher.PublishedBookEditions.Count(be => be.DeletedDate == null),
            IsActive = publisher.DeletedDate == null
        });
    }
}
