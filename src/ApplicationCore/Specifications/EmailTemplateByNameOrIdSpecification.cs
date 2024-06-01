using Ardalis.Specification;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.ApplicationCore.Specifications;

public class EmailTemplateByNameOrIdSpecification : SingleResultSpecification<EmailTemplate>
{
    public EmailTemplateByNameOrIdSpecification(string templateName)
    {
        Query
            .Where(et => et.Name == templateName);
    }
    public EmailTemplateByNameOrIdSpecification(int templateId)
    {
        Query
            .Where(et => et.Id == templateId);
    }
}
