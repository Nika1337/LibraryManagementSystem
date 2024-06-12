using System;

namespace Nika1337.Library.Domain.Exceptions;

public class PasswordStructureValidationException : Exception
{
    public PasswordStructureValidationException(string message) : base(message) {

    }
}
