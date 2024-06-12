

namespace Nika1337.Library.Domain.Exceptions;

public class EmailTemplateNotFoundException : NotFoundException
{
    public EmailTemplateNotFoundException(int id) : base($"No email template found with id '{id}'")
    {

    }
}
