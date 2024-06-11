

using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Genres;
public class GenreCreateViewModel
{
    [StringLength(50)]
    [Required]
    public string Name { get; set; }

    [StringLength(500)]
    [Required]
    public string Description { get; set; }
    public string? ErrorMessage { get; set; }
}
