

using System;

namespace Nika1337.Library.Presentation.Models.BookEditions;

public class BookEditionPreviewViewModel
{
    public required int Id { get; init; }
    public required string BookTitle { get; init; }
    public required string PublisherName { get; init; }
    public required string LanguageName { get; init; }
    public required string RoomNumber { get; init; }
    public required string Isbn { get; init; }
    public required int? PageCount { get; init; }
    public required DateTime PublicationDate { get; init; }
    public required bool IsActive { get; init; }
}
