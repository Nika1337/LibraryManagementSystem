using Nika1337.Library.Presentation.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Checkouts;

public class CheckoutCreateViewModel
{
    [Required(ErrorMessage = "Please specify account which wants to checkout copies")]
    [DisplayName("Account")]
    [NotZero(ErrorMessage = "Please specify account which wants to checkout copies")]
    public int AccountId { get; set; }

    [Required(ErrorMessage = "Please select a book to checkout")]
    [DisplayName("Book")]
    [NotZero(ErrorMessage = "Please select a book to checkout")]
    public int BookId { get; set; }

    [Required(ErrorMessage = "Please select a book edition to checkout")]
    [DisplayName("Book Edition")]
    [NotZero(ErrorMessage = "Please select a book edition to checkout")]
    public int BookEditionId { get; set; }

    [Required(ErrorMessage = "Please select how many copies to checkout")]
    [DisplayName("Copies Count")]
    [NotZero(ErrorMessage = "Please select how many copies to checkout")]
    public int CopiesCount { get; set; }

    [Required(ErrorMessage = "Please specify when the copies should be returned")]
    [DisplayName("Supposed Return Time")]
    [MinOneDayFromNow(ErrorMessage = "Supposed return time must be at least one day from now.")]
    public DateTime SupposedReturnTime { get; set; } = DateTime.Now.AddDays(1);

    public string? ErrorMessage { get; set; }
}

