

using Nika1337.Library.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace Nika1337.Library.Application.DataTransferObjects;

public record EmployeeDetailedResponse(
    string FirstName,
    string LastName,
    string Username,
    string IdNumber,
    DateTime DateOfBirth,
    decimal Salary,
    DateTime StartDate,
    string? PhoneNumber,
    string? Email,
    Address? Address,
    Gender? Gender,
    DateTime? TerminationDate,
    ICollection<string> RoleNames);
