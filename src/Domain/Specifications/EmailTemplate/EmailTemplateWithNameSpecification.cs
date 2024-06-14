using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.EmailTemplates;

public class EmailTemplateWithNameSpecification : SingleResultSpecification<EmailTemplate>
{

    public EmailTemplateWithNameSpecification(string name)
    {
        Query
            .Where(et => et.Name == name);
    }
}
