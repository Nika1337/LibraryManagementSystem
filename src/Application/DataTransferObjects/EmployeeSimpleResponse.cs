
using System;

namespace Nika1337.Library.Application.DataTransferObjects;
public record EmployeeSimpleResponse(
    string Id,
    string FirstName,
    string LastName,
    string Username,
    string? Email,
    string? PhoneNumber,
    DateTime DateOfBirth,
    string IdNumber,
    DateTime StartDate,
    bool IsActive);