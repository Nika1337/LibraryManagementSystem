using System;

namespace Nika1337.Library.ApplicationCore.Exceptions;
public class DuplicateException : Exception
{
    public DuplicateException(string message) : base(message)
    {
    }
}
