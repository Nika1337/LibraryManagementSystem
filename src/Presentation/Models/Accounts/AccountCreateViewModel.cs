

using Nika1337.Library.Presentation.Models.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Accounts;

public class AccountCreateViewModel
{
    [Required]
    [DisplayName("Account Name")]
    [StringLength(80)]
    public string AccountName { get; set; }

    [Required]
    [DisplayName("Customer Identification")]
    [StringLength(30)]
    public string CustomerIdentification { get; set; }
    public ContactInformationViewModel ContactInformation { get; set; } = new();
    public string? ErrorMessage { get; set; }
}
