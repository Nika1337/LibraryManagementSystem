
using Nika1337.Library.Presentation.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Books;

public class BookDetailViewModel
{
    public required int Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string Title { get; set; }

    [Required]
    [StringLength(300)]
    public required string Summary { get; set; }

    [Required]
    [DisplayName("Original Release Date")]
    public required DateTime OriginalReleaseDate { get; set; }
    public required byte? MinimumAge { get; set; }

    [Required(ErrorMessage = "Original Language is required")]
    public required int OriginalLanguageId { get; set; }

    [AtLeastOneElement(ErrorMessage = "Books need to have at least one genre")]
    public int[]? GenreIds { get; set; }

    [AtLeastOneElement(ErrorMessage = "Books need to have at least one author")]
    public int[]? AuthorIds { get; set; }

    public DateTime? DeletedDate { get; set; }
    public string? ErrorMessage { get; set; }
}
