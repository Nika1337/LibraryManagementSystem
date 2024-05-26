using System;

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class PasswordStructureValidationException : Exception
{
    public PasswordStructureValidationException(string message) : base(message) {

    }
}
