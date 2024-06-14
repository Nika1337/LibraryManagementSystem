using System;

namespace Nika1337.Library.Domain.Exceptions;


public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    { 

    }
}
