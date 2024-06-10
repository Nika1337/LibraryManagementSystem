using Ardalis.Specification;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.ApplicationCore.Specifications;

public class EmailTemplateSpecification : SingleResultSpecification<EmailTemplate>
{
    public EmailTemplateSpecification(int templateId)
    {
        Query
            .Where(et => et.Id == templateId);
    }

    public EmailTemplateSpecification(string name)
    {
        Query
            .Where(et => et.Name == name);
    }
}
