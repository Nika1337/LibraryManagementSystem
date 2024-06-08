using System;

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class PasswordIncorrectException : Exception
{
    public PasswordIncorrectException(string id) : base($"Password for user with id '{id}' is incorrect")
    {

    }
}
