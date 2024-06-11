

using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Genres;

public class GenreViewModel
{
    public int Id { get; set; }

    [StringLength(50)]
    [Required]
    public required string Name { get; set; }

    [StringLength(500)]
    [Required]
    public required string Description { get; set; }
    public required string? DeletedDate { get; set; }
}
