

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class UsernameDuplicateException : DuplicateException
{
    public UsernameDuplicateException(string message) : base(message)
    {
    }
}
