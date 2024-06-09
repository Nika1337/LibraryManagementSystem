
using System;

namespace Nika1337.Library.Application.DataTransferObjects;
public record EmployeeRegistrationRequest(
    string FirstName,
    string LastName,
    string Username,
    string IdNumber,
    DateTime DateOfBirth,
    decimal Salary,
    string[] Roles);
