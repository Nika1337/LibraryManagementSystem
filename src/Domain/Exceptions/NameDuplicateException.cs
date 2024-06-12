

namespace Nika1337.Library.Domain.Exceptions;

public class NameDuplicateException : DuplicateException
{
    public NameDuplicateException(string message) : base(message)
    {
    }
}
