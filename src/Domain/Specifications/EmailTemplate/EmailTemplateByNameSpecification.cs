using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.EmailTemplates;

public class EmailTemplateByNameSpecification : SingleResultSpecification<EmailTemplate>
{

    public EmailTemplateByNameSpecification(string name)
    {
        Query.Where(et => et.Name == name);
    }
}
