

using Nika1337.Library.Presentation.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Nika1337.Library.Presentation.Models.Accounts;
public class AccountDetailedViewModel
{
    public required int Id { get; init; }
    [Required]
    [DisplayName("Account Name")]
    [StringLength(80)]
    public required string AccountName { get; set; }

    [Required]
    [DisplayName("Customer Identification")]
    [StringLength(30)]
    public required string CustomerIdentification { get; set; }
    public ContactInformationViewModel ContactInformation { get; set; }

    [DisplayName("Account Creation Date")]
    public required DateTime AccountCreationDate { get; init; }

    [DisplayName("Total Checkouts")]
    public required int TotalCheckouts { get; set; }

    [DisplayName("Active Checkouts")]
    public required int ActiveCheckouts { get; set; }

    public required DateTime? DeletedDate { get; init; }

    public string? ErrorMessage { get; set; }
}
