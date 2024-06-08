using System;

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class TerminatedEmployeeSignInException : Exception
{
    public TerminatedEmployeeSignInException(string username) : base($"Employee with username '{username}' is terminated")
    {

    }
}
