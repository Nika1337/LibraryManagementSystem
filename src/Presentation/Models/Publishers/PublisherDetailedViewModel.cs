

using Nika1337.Library.Presentation.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Nika1337.Library.Presentation.Models.Publishers;

public class PublisherDetailedViewModel
{
    public required int Id { get; set; }
    [Required(ErrorMessage = "Publisher should have a name")]
    [StringLength(100)]
    [DisplayName("Publisher Name")]
    public required string PublisherName { get; set; }

    [StringLength(100)]
    [DisplayName("Website Address")]
    public required string? WebsiteAddress { get; set; }

    public required ContactInformationViewModel ContactInformation { get; set; }

    public required int PublishedBookEditionsCount { get; init; }

    public required DateTime? DeletedDate { get; init; }

    public string? ErrorMessage { get; set; }
}
