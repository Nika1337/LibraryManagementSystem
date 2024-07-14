
using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Publishers;

public class PublisherByIdSpecification : BaseModelByIdSpecification<Publisher>
{
    public PublisherByIdSpecification(int id) : base(id)
    {
        Query.Include(publisher => publisher.PublishedBookEditions);
    }
}
