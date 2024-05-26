using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models;

public class EmployeeEditViewModel
{
    [Required]
    [Display(Name = "First Name")]
    public required string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public required string LastName { get; set; }

    [Required]
    [Display(Name = "Username")]
    public required string NewUsername { get; set; }

    [Required]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public required DateTime DateOfBirth { get; set; }

    [Required]
    [Display(Name = "ID Number")]
    public required string IdNumber { get; set; }

    [Required]
    [Display(Name = "Salary")]
    public required decimal Salary { get; set; }

    [Display(Name = "Start Date")]
    public required DateTime StartDate { get; set; }

    [Display(Name = "Termination Date")]
    public required DateTime? TerminationDate { get; set; }

    [Required]
    [Display(Name = "Roles")]
    public required List<string> SelectedRoles { get; set; } = [];

    public required List<SelectListItem> AvailableRoles { get; set; } = [];
}