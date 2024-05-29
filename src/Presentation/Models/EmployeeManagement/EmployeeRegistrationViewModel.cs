using Nika1337.Library.Presentation.Validation.Date;
using Nika1337.Library.Presentation.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.EmployeeManagement;

public class EmployeeRegistrationViewModel
{
    [Required(ErrorMessage = "First Name is required.")]
    [Display(Name = "First Name")]
    [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    [Display(Name = "Last Name")]
    [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [Display(Name = "Username")]
    [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(DateValidator), nameof(DateValidator.ValidateDateOfBirth))]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "ID Number is required.")]
    [Display(Name = "ID Number")]
    [StringLength(20, ErrorMessage = "ID Number cannot be longer than 20 characters.")]
    public string IdNumber { get; set; }

    [Required(ErrorMessage = "Starting Salary is required.")]
    [Display(Name = "Starting Salary")]
    [DataType(DataType.Currency)]
    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
    public decimal Salary { get; set; }

    [Required(ErrorMessage = "At least one role must be selected.")]
    [Display(Name = "Roles")]
    [AtLeastOneElement(ErrorMessage = "At least one role must be selected.")]
    public List<string> SelectedRoles { get; set; } = [];

    public List<string> AvailableRoles { get; set; } = [];
}