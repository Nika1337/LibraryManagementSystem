using System;

namespace Nika1337.Library.Application.DataTransferObjects;

public record EmployeeManagerUpdateRequest(
    string Id,
    string FirstName,
    string LastName,
    string Username,
    string IdNumber,
    DateTime DateOfBirth,
    string Salary,
    string[] RoleNames) : EmployeeUpdateRequest(Id, FirstName, LastName, Username);
