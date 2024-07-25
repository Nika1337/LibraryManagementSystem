

using Nika1337.Library.Presentation.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Books;

public class BookCreateViewModel
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    [Required]
    [StringLength(300)]
    public string Summary { get; set; }
    [Required]
    [DisplayName("Original Release Date")]
    public DateTime OriginalReleaseDate { get; set; } = DateTime.Now;

    [DisplayName("Minimum Age")]
    public byte? MinimumAge { get; set; }

    [Required(ErrorMessage = "Original Language is required")]
    [DisplayName("Original Language")]
    [NotZero(ErrorMessage = "Original Language is required")]
    public int OriginalLanguageId { get; set; }

    [AtLeastOneElement(ErrorMessage = "Books need to have at least one genre")]
    [DisplayName("Genres")]
    public IList<int> GenreIds { get; set; } = [];

    [AtLeastOneElement(ErrorMessage = "Books need to have at least one author")]
    [DisplayName("Authors")]
    public IList<int> AuthorIds { get; set; } = [];

    public string? ErrorMessage { get; set; }
}
