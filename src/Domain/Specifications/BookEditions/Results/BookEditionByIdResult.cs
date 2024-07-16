using System;

namespace Nika1337.Library.Domain.Specifications.BookEditions.Results;

public class BookEditionByIdResult
{
    public required int Id { get; init; }
    public required string Isbn { get; init; }
    public required int? PageCount { get; init; }
    public required DateTime PublicationDate { get; init; }
    public required int BookId { get; init; }
    public required int LanguageId { get; init; }
    public required int PublisherId { get; init; }
    public required int RoomId { get; init; }
    public required int TotalCopiesCount { get; init; }
    public required int AvaliableCopiesCount { get; init; }
    public required DateTime? DeletedDate { get; init; }
}
