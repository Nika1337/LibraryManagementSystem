

using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Languages;

public class LanguageCreateViewModel
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    public string? ErrorMessage { get; set; }
}
