
using System;

namespace Nika1337.Library.Domain.Exceptions;

public class NotFoundException<T> : Exception
{
    public NotFoundException(int id) : base($"No {typeof(T).Name} Found with id '{id}'")
    {
    }
}
