using Nika1337.Library.Presentation.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.BookEditions;

public class BookEditionCreateViewModel
{
    [Required(ErrorMessage = "Book Edition must have ISBN")]
    [DisplayName("ISBN")]
    [StringLength(20)]
    public string Isbn { get; set; }

    [DisplayName("Page Count")]
    public int? PageCount { get; set; }

    [Required(ErrorMessage = "Book Edition must have publication date")]
    [DisplayName("Publication Date")]
    public DateTime? PublicationDate { get; set; } = null;

    [DisplayName("Language")]
    [Required(ErrorMessage = "Book Edition must have language")]
    [NotZero(ErrorMessage = "Book Edition must have language")]
    public int LanguageId { get; set; }

    [DisplayName("Publisher")]
    [Required(ErrorMessage = "Book Edition must have publisher")]
    [NotZero(ErrorMessage = "Book Edition must have publisher")]
    public int PublisherId { get; set; }

    [DisplayName("Room")]
    [Required(ErrorMessage = "Book Edition must be in a room")]
    [NotZero(ErrorMessage = "Book Edition must be in a room")]
    public int RoomId { get; set; }

    [DisplayName("Copies Count")]
    [Required(ErrorMessage = "Book Edition must be added with some copies")]
    [NotZero(ErrorMessage = "Book Edition must be added with some copies")]
    public int CopiesCount { get; set; }

    public string? ErrorMessage { get; set; }
}
