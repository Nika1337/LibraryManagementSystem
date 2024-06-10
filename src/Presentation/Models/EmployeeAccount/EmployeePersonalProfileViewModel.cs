namespace Nika1337.Library.Presentation.Models.EmployeeAccount;

using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.Presentation.Validation.Date;
using System;
using System.ComponentModel.DataAnnotations;

public class EmployeePersonalProfileViewModel
{
    public string Id { get; set; }
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
    public string Username { get; init; }

    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    [StringLength(15, ErrorMessage = "Phone Number cannot be longer than 15 characters.")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public Gender? Gender { get; set; }

    [Required(ErrorMessage = "ID Number is required.")]
    [Display(Name = "ID Number")]
    [StringLength(20, ErrorMessage = "ID Number cannot be longer than 20 characters.")]
    public string IdNumber { get; init; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(DateValidator), nameof(DateValidator.ValidateDateOfBirth))]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string? Email { get; init; }

    [Display(Name = "Salary")]
    [DataType(DataType.Currency)]
    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
    public decimal Salary { get; init; }

    [Required(ErrorMessage = "Start Date is required.")]
    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; init; }



    [Display(Name = "Country")]
    [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters.")]
    public string? Country { get; set; }

    [Display(Name = "State")]
    [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters.")]
    public string? State { get; set; }

    [Display(Name = "City")]
    [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
    public string? City { get; set; }

    [Display(Name = "Street")]
    [StringLength(100, ErrorMessage = "Street cannot be longer than 100 characters.")]
    public string? Street { get; set; }

    [Display(Name = "Postal Code")]
    [StringLength(10, ErrorMessage = "Postal Code cannot be longer than 10 characters.")]
    public string? PostalCode { get; set; }


    public string? ErrorMessage { get; set; }
}
