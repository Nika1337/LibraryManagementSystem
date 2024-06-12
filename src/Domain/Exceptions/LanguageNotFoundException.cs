namespace Nika1337.Library.Domain.Exceptions;

public class LanguageNotFoundException : NotFoundException
{
    public LanguageNotFoundException(int id) : base($"No Language found with id '{id}'")
    {
    }
}