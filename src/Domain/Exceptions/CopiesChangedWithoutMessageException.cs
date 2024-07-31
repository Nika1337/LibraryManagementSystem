using System;
namespace Nika1337.Library.Domain.Exceptions;

public class CopiesChangedWithoutMessageException : Exception
{
    public CopiesChangedWithoutMessageException() : base("Book Copy Changed without a reason message!")
    {
    }
}
