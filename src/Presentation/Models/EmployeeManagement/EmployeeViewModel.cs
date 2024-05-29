using System;

namespace Nika1337.Library.Presentation.Models.EmployeeManagement;

public record EmployeeViewModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Username { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string IdNumber { get; set; }
    public DateTime StartDate { get; set; }
    public required bool IsActive { get; set; }
}