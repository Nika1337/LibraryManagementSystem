using Ardalis.Specification;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.ApplicationCore.Specifications;

public class EmailTemplateSpecification : SingleResultSpecification<EmailTemplate>
{

    public EmailTemplateSpecification(string name, int id)
    {
        Query
            .Where(et => et.Name == name && et.Id != id);
    }
}
