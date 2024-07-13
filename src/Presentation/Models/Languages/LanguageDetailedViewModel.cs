using System;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Languages;

public class LanguageDetailedViewModel
{
    public required int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    public required DateTime? DeletedDate { get; set; }
    public string? ErrorMessage { get; set; }
}
