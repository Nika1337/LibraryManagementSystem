using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Shared;

public class AddressViewModel
{
    [Display(Name = "Country")]
    [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters.")]
    public string? Country { get; set; }

    [Display(Name = "State")]
    [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters.")]
    public string? State { get; set; }

    [Display(Name = "City")]
    [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
    public string? City { get; set; }

    [Display(Name = "Street")]
    [StringLength(100, ErrorMessage = "Street cannot be longer than 100 characters.")]
    public string? Street { get; set; }

    [Display(Name = "Postal Code")]
    [StringLength(10, ErrorMessage = "Postal Code cannot be longer than 10 characters.")]
    public string? PostalCode { get; set; }
}
