

namespace Nika1337.Library.Domain.Exceptions;

public class IsbnDuplicateException : DuplicateException
{
    public IsbnDuplicateException(string isbn) : base($"Book Edition with Isbn '{isbn}' already exists")
    {
    }
}
