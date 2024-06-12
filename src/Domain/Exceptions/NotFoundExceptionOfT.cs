using Nika1337.Library.ApplicationCore.Entities;
using System;


namespace Nika1337.Library.ApplicationCore.Exceptions;

public class NotFoundException<T> : Exception where T : BaseModel
{
    public NotFoundException(int id) : base($"No {nameof(T)} Found with id '{id}'")
    {

    }
}
