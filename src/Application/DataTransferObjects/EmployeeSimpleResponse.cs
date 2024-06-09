
using System;

namespace Nika1337.Library.Application.DataTransferObjects;
public record EmployeeSimpleResponse
{
    public required string Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Username { get; init; }
    public required string? Email { get; init; }
    public required string? PhoneNumber { get; init; }
    public required DateTime DateOfBirth { get; init; }
    public required string IdNumber { get; init; }
    public required DateTime StartDate { get; init; }
    public required bool IsActive { get; init; }
}
