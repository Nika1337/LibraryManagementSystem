using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications;

public class EmailTemplateSpecification : SingleResultSpecification<EmailTemplate>
{

    public EmailTemplateSpecification(string name, int id)
    {
        Query
            .Where(et => et.Name == name && et.Id != id);
    }
}
