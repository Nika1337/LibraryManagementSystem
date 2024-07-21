using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Checkouts;

public class CheckoutCreateViewModel
{
    [Required(ErrorMessage = "Please specify account which wants to checkout copies")]
    [DisplayName("Account")]
    public int AccountId { get; set; }

    [Required(ErrorMessage = "Please select a book to checkout")]
    [DisplayName("Book")]
    public int BookId { get; set; }

    [Required(ErrorMessage = "Please select a book edition to checkout")]
    [DisplayName("Book Edition")]
    public int BookEditionId { get; set; }

    [Required(ErrorMessage = "Please select how many copies to checkout")]
    [DisplayName("Copies Count")]
    public int CopiesCount { get; set; }

    [Required(ErrorMessage = "Please specify when the copies should be returned")]
    [DisplayName("Supposed Return Time")]
    public DateTime SupposedReturnTime { get; set; }

    public string? ErrorMessage { get; set; }
}

