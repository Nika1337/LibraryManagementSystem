using System;
using System.Security.Claims;

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class EmployeeNotFoundException : Exception
{
    public EmployeeNotFoundException(string username) : base($"No employee found with username '{username}'")
    { 
    }
    public EmployeeNotFoundException(ClaimsPrincipal claimsPrincipal) : base($"No employee found for claims principal '{claimsPrincipal}'")
    {
    }
}
