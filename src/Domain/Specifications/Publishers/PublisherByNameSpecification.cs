using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.Publishers;

public class PublisherByNameSpecification : SingleResultSpecification<Publisher>
{
    public PublisherByNameSpecification(string name)
    {
        Query.Where(publisher => publisher.PublisherName == name);
    }
}
