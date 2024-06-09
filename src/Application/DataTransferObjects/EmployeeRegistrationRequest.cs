
using System;

namespace Nika1337.Library.Application.DataTransferObjects;
public record EmployeeRegistrationRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Username { get; init; }
    public required string IdNumber { get; init; }
    public required DateTime DateOfBirth { get; init; }
    public required decimal Salary { get; init; }
    public required string[] Roles { get; init; }
}
