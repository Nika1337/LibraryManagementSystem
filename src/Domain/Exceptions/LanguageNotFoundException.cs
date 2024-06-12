namespace Nika1337.Library.ApplicationCore.Exceptions;

public class LanguageNotFoundException : NotFoundException
{
    public LanguageNotFoundException(int id) : base($"No Language found with id '{id}'")
    {
    }
}