

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class EmailTemplateNotFoundException : NotFoundException
{
    public EmailTemplateNotFoundException(int templateId) : base($"No email template found with id '{templateId}'")
    {

    }
}
