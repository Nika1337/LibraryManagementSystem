using Nika1337.Library.Presentation.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Checkouts;

public class CheckoutCreateViewModel
{
    [Required(ErrorMessage = "Please specify account which wants to checkout copies")]
    [DisplayName("Account")]
    [NotZero]
    public int AccountId { get; set; }

    [Required(ErrorMessage = "Please select a book to checkout")]
    [DisplayName("Book")]
    [NotZero]
    public int BookId { get; set; }

    [Required(ErrorMessage = "Please select a book edition to checkout")]
    [DisplayName("Book Edition")]
    [NotZero]
    public int BookEditionId { get; set; }

    [Required(ErrorMessage = "Please select how many copies to checkout")]
    [DisplayName("Copies Count")]
    [NotZero]
    public int CopiesCount { get; set; }

    [Required(ErrorMessage = "Please specify when the copies should be returned")]
    [DisplayName("Supposed Return Time")]
    public DateTime SupposedReturnTime { get; set; } = DateTime.Now;

    public string? ErrorMessage { get; set; }
}

