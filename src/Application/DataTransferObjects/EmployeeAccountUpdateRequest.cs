using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.Application.DataTransferObjects;

public record EmployeeAccountUpdateRequest(
    string Id,
    string FirstName,
    string LastName,
    string Username,
    string? PhoneNumber,
    Gender Gender,
    Address Address) : EmployeeUpdateRequest(Id, FirstName, LastName, Username);