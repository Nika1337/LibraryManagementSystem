using System;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Authors;

public class AuthorDetailViewModel
{
    public required int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(1000)]
    public required string Biography { get; set; }

    [Required]
    [Display(Name = "Date Of Birth")]
    public required DateTime DateOfBirth { get; set; }

    [Required]
    [Display(Name = "Alive")]
    public required bool IsAlive { get; set; }
    public required DateTime? DeletedDate { get; set; }
    public string? ErrorMessage { get; set; }
}
