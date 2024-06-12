using System;

namespace Nika1337.Library.Domain.Exceptions;
public class DuplicateException : Exception
{
    public DuplicateException(string message) : base(message)
    {
    }
}
