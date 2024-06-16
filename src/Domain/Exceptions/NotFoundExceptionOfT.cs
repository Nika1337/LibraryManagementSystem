
using System;

namespace Nika1337.Library.Domain.Exceptions;

public class NotFoundException<T> : Exception
{
    public NotFoundException(int id) : base($"No {typeof(T).Name} Found with id '{id}'")
    {
    }
    public NotFoundException(int[] ids) : base($"No {typeof(T).Name} Found for at least one of ids [{string.Join(", ", ids)}]")
    {

    }
}
