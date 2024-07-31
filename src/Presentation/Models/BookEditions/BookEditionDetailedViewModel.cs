
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Nika1337.Library.Presentation.Validation;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Nika1337.Library.Presentation.Models.BookEditions;

public class BookEditionDetailedViewModel
{
    public required int Id { get; init; }

    [Required(ErrorMessage = "Book Edition must have ISBN")]
    [DisplayName("ISBN")]
    [StringLength(20)]
    public required string Isbn { get; set; }

    [DisplayName("Page Count")]
    public required int? PageCount { get; set; }

    [Required(ErrorMessage = "Book Edition must have publication date")]
    [DisplayName("Publication Date")]
    public required DateTime PublicationDate { get; set; }

    [DisplayName("Language")]
    [Required(ErrorMessage = "Book Edition must have language")]
    [NotZero(ErrorMessage = "Book Edition must have language")]
    public required int LanguageId { get; set; }

    [DisplayName("Publisher")]
    [Required(ErrorMessage = "Book Edition must have publisher")]
    [NotZero(ErrorMessage = "Book Edition must have publisher")]
    public required int PublisherId { get; set; }

    [DisplayName("Room")]
    [Required(ErrorMessage = "Book Edition must be in a room")]
    [NotZero(ErrorMessage = "Book Edition must be in a room")]
    public required int RoomId { get; set; }

    [DisplayName("Book")]
    public required string BookTitle { get; init; }

    [DisplayName("Total Copies Count")]
    public required int TotalCopiesCount { get; init; }

    [DisplayName("Available Copies Count")]
    public required int AvaliableCopiesCount { get; set; }
    [DisplayName("Reason for Change")]
    public string? CopiesChangeReasonMessage { get; set; }
    public required List<BookEditionCopiesAuditEntryViewModel>? Audit { get; set; }

    [HiddenInput]
    public string? SerializedAudit { get; set; }

    [DisplayName("Deleted Date")]
    public required DateTime? DeletedDate { get; init; }
    public string? ErrorMessage { get; set; }
}
