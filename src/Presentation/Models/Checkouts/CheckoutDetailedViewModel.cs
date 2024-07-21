

using System;
using System.ComponentModel;

namespace Nika1337.Library.Presentation.Models.Checkouts;

public class CheckoutDetailedViewModel
{
    public required int Id { get; init; }

    [DisplayName("Book Title")]
    public required string BookTitle { get; init; }

    [DisplayName("Publisher Name")]
    public required string PublisherName { get; init; }

    [DisplayName("Language Name")]
    public required string LanguageName { get; init; }

    [DisplayName("Copies Taken Count")]
    public required int CopiesCount { get; init; }

    [DisplayName("Account Name")]
    public required string AccountName { get; init; }

    [DisplayName("Checkout Time")]
    public required DateTime CheckoutTime { get; init; }

    [DisplayName("Supposed Return Time")]
    public required DateTime SupposedReturnTime { get; init; }


    [DisplayName("Checkout Close Time")]
    public required DateTime? CheckoutCloseTime { get; init; }

    [DisplayName("Returned Copies Count")]
    public required int ReturnedCopiesCount { get; set; }

    [DisplayName("Lost Copies Count")]
    public required int LostCopiesCount { get; set; }

    [DisplayName("Damaged Copies Count")]
    public required int DamagedCopiesCount { get; set; }

    [DisplayName("Destroyed Copies Count")]
    public required int DestroyedCopiesCount { get; set; }

    [DisplayName("Deleted Date")]
    public required DateTime? DeletedDate { get; init; }
    public string? ErrorMessage { get; init; }
}
