
using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Publishers.Results;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Publishers;

public class PublisherDetailedSpecification : BaseModelByIdSpecification<Publisher, PublisherDetailedResult>
{
    public PublisherDetailedSpecification(int id) : base(id)
    {

        Query.Select(publisher => new PublisherDetailedResult
        {
            Id = publisher.Id,
            PublisherName = publisher.PublisherName,
            ContactInformation = publisher.ContactInformation,
            WebsiteAddress = publisher.WebsiteAddress,
            PublishedBookEditionsCount = publisher.PublishedBookEditions.Count(be => be.DeletedDate == null),
            DeletedDate = publisher.DeletedDate
        });
    }
}
