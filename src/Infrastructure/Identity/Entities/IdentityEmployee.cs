using Microsoft.AspNetCore.Identity;
using Nika1337.Library.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace Nika1337.Library.Infrastructure.Identity.Entities;

internal class IdentityEmployee : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string IdNumber { get; set; }
    public Address? Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Salary { get; set; }
    public Gender? Gender { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? TerminationDate { get; set; }
}
