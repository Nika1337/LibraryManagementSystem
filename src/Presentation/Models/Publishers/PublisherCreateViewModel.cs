

using Nika1337.Library.Presentation.Models.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Publishers;

public class PublisherCreateViewModel
{
    [Required(ErrorMessage = "Publisher should have a name")]
    [StringLength(100)]
    [DisplayName("Publisher Name")]
    public string PublisherName { get; set; }

    [StringLength(100)]
    [DisplayName("Website Address")]
    public string? WebsiteAddress { get; set; }

    public ContactInformationViewModel ContactInformation { get; set; } = new();

    public string? ErrorMessage { get; set; }
}
