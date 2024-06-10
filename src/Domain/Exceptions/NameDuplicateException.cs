

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class NameDuplicateException : DuplicateException
{
    public NameDuplicateException(string message) : base(message)
    {
    }
}
