using System;

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class EmployeeRoleNotFoundException : Exception
{
    public EmployeeRoleNotFoundException(string roleName) : base($"No Role found with Name '{roleName}'")
    {
    }

    public EmployeeRoleNotFoundException(string[] roleNames) : base($"No Role found for at least on specified name in [{String.Join(", ", roleNames)}]") {

    }

}
