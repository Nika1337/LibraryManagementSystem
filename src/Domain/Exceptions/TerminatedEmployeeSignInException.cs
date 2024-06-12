using System;

namespace Nika1337.Library.Domain.Exceptions;

public class TerminatedEmployeeSignInException : Exception
{
    public TerminatedEmployeeSignInException(string username) : base($"Employee with username '{username}' is terminated")
    {

    }
}
