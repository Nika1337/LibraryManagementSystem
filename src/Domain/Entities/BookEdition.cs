using System;
using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;
public class BookEdition : BaseModel
{
    public required Book Book { get; set; }
    public required string Isbn { get; set; }
    public int? PageCount { get; set; }
    public required Publisher Publisher { get; set; }
    public required DateTime PublicationDate { get; set; }
    public required Language Language { get; set; }
    public required Room Room { get; set; }
    public List<BookCopy> Copies { get; set; } = [];
    public List<BookEditionCopiesAuditEntry> Audit { get; set; } = [];
    public List<Checkout> Checkouts { get; set; } = [];
}