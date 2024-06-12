

using Nika1337.Library.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Nika1337.Library.Application.DataTransferObjects;

public record EmployeeDetailedResponse
{
    public required string Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Username { get; init; }
    public required string IdNumber { get; init; }
    public required DateTime DateOfBirth { get; init; }
    public required decimal Salary { get; init; }
    public required DateTime StartDate { get; init; }
    public required string? PhoneNumber { get; init; }
    public required string? Email { get; init; }
    public required Address Address { get; init; }
    public required Gender? Gender { get; init; }
    public required DateTime? TerminationDate { get; init; }
    public required ICollection<string> RoleNames { get; init; }
}
