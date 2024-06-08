using System;
using System.Security.Claims;

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(string id) : base($"No employee found with id '{id}'")
    { 
    }
    public EmployeeNotFoundException(ClaimsPrincipal claimsPrincipal) : base($"No employee found for claims principal '{claimsPrincipal}'")
    {
    }
}
