using Ardalis.Specification;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.ApplicationCore.Specifications;

public class EmailTemplateSpecification : SingleResultSpecification<EmailTemplate>
{
    public EmailTemplateSpecification(string templateName)
    {
        Query
            .Where(et => et.Name == templateName);
    }
}
