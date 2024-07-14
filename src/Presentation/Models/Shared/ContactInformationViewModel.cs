

using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Shared;

public class ContactInformationViewModel
{
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(255)]
    public string Email { get; set; }

    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    [StringLength(15, ErrorMessage = "Phone Number cannot be longer than 15 characters.")]
    public string PhoneNumber { get; set; }
    public AddressViewModel Address { get; set; }
}
