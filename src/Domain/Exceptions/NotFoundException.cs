using Nika1337.Library.Domain.Entities;
using System;

namespace Nika1337.Library.Domain.Exceptions;

public class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message)
    {
    }
}
