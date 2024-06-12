using System;


namespace Nika1337.Library.Domain.Entities;
public class PersonalAccount : Account
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Gender Gender { get; set; }
    public required string IdNumber { get; set; }
    public required DateTime DateOfBirth { get; set; }
}