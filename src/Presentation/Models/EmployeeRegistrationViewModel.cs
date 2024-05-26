using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models;

public class EmployeeRegistrationViewModel
{
    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Required]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [Display(Name = "ID Number")]
    public string IdNumber { get; set; }

    [Required]
    [Display(Name = "Starting Salary")]
    public decimal Salary { get; set; }

    [Required]
    [Display(Name = "Roles")]
    public List<string> SelectedRoles { get; set; } = [];

    public List<SelectListItem> AvailableRoles { get; set; } = [];
}