

using System;
using System.Collections.Generic;

namespace Nika1337.Library.ApplicationCore.Entities;

public class Employee
{
    public required string FirstName { get; set;}
    public required string LastName { get; set; }
    public required string Username { get; set; }
    public required string IdNumber { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required decimal Salary { get; set; }
    public required DateTime StartDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get;set; }
    public Address? Address { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? TerminationDate { get; set; }
    public ICollection<EmployeeRole> Roles { get; set; } = [];
}
