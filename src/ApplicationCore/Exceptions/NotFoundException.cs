using System;

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message)
    {
    }
}
