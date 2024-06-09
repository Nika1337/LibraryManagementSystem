using Ardalis.Specification;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.ApplicationCore.Specifications;

public class EmailTemplateByIdSpecification : SingleResultSpecification<EmailTemplate>
{
    public EmailTemplateByIdSpecification(int templateId)
    {
        Query
            .Where(et => et.Id == templateId);
    }
}
