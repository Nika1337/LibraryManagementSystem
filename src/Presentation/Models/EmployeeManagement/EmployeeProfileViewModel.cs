
using Nika1337.Library.Presentation.Validation.Date;
using Nika1337.Library.Presentation.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Presentation.Models.EmployeeManagement;

public class EmployeeProfileViewModel
{
    public required string Id { get; set; }
    [Required(ErrorMessage = "First Name is required.")]
    [Display(Name = "First Name")]
    [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    [Display(Name = "Last Name")]
    [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [Display(Name = "Username")]
    [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(DateValidator), nameof(DateValidator.ValidateDateOfBirth))]
    public required DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "ID Number is required.")]
    [Display(Name = "ID Number")]
    [StringLength(20, ErrorMessage = "ID Number cannot be longer than 20 characters.")]
    public required string IdNumber { get; set; }

    [Required(ErrorMessage = "Salary is required.")]
    [Display(Name = "Salary")]
    [DataType(DataType.Currency)]
    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
    public required decimal Salary { get; set; }



    [Required(ErrorMessage = "At least one role must be selected.")]
    [Display(Name = "Roles")]
    [AtLeastOneElement(ErrorMessage = "At least one role must be selected.")]
    public List<string> SelectedRoles { get; set; } = [];

    public string[] AvailableRoles { get; set; } = [];


    [Display(Name = "Country")]
    public required string? Country { get; init; }

    [Display(Name = "State")]
    public required string? State { get; init; }

    [Display(Name = "City")]
    public required string? City { get; init; }

    [Display(Name = "Street")]
    public required string? Street { get; init; }

    [Display(Name = "Postal Code")]
    public required string? PostalCode { get; init; }


    public required Gender? Gender { get; init; }

    public required string? Email { get; init; }

    public required string? PhoneNumber { get; init; }

    [DataType(DataType.Date)]
    public required DateTime StartDate { get; init; }

    [DataType(DataType.Date)]
    public required DateTime? TerminationDate { get; init; }

    public string? ErrorMessage { get; set; }
}
