

namespace Nika1337.Library.Presentation.Models.EmployeeAccount;

using Nika1337.Library.ApplicationCore.Entities;
using System;
using System.ComponentModel.DataAnnotations;

public class EmployeeProfileViewModel
{

    [Required]
    [Display(Name = "First Name")]
    public required string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public required string LastName { get; set; }

    [Required]
    [Display(Name = "Username")]
    public required string Username { get; init; }

    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    public required string? PhoneNumber { get; set; }

    [Required]
    public required Gender? Gender { get; set; }

    [Required]
    [Display(Name = "ID Number")]
    public required string IdNumber { get; init; }


    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public required DateTime DateOfBirth { get; set; }

    [Display(Name = "Email")]
    [EmailAddress]
    public required string? Email { get; init; }

    [Display(Name = "Salary")]
    [DataType(DataType.Currency)]
    public required decimal Salary { get; init; }

    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public required DateTime StartDate { get; init; }



    [Display(Name = "Country")]
    public required string? Country { get; set; }

    [Display(Name = "State")]
    public required string? State { get; set; }


    [Display(Name = "City")]
    public required string? City { get; set; }

    [Display(Name = "Street")]
    public required string? Street { get; set; }


    [Display(Name = "Postal Code")]
    public required string? PostalCode { get; set; }
}
