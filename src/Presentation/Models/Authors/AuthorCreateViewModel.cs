using System;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Authors;

public class AuthorCreateViewModel
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000)]
    public string Biography { get; set; }

    [Required]
    [Display(Name = "Date Of Birth")]
    public DateTime? DateOfBirth { get; set; } = null;

    [Required]
    [Display(Name = "Alive")]
    public bool IsAlive { get; set; }

    public string? ErrorMessage { get; set; }
}
