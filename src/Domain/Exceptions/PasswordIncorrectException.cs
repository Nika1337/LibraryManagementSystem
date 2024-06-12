using System;

namespace Nika1337.Library.Domain.Exceptions;

public class PasswordIncorrectException : Exception
{
    public PasswordIncorrectException(string id) : base($"Password for user with id '{id}' is incorrect")
    {

    }
}
