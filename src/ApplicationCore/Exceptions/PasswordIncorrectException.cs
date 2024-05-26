using System;

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class PasswordIncorrectException : Exception
{
    public PasswordIncorrectException(string username) : base($"Password for user with username '{username}' is incorrect")
    {

    }
}
