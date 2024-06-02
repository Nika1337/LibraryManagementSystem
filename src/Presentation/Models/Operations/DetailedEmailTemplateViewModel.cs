

using System;
using System.ComponentModel;

namespace Nika1337.Library.Presentation.Models.Operations;

public class DetailedEmailTemplateViewModel
{
    public required int Id { get; set; }

    [DisplayName("Name")]
    public required string Name { get; set; }

    [DisplayName("Brief Description")]
    public required string BriefDescription { get; set; }

    [DisplayName("Subject")]
    public required string Subject { get; set; }

    [DisplayName("From Email")]
    public required string FromEmail { get; set; }

    [DisplayName("Separator")]
    public required string Separator { get; set; }

    [DisplayName("Body")]
    public required string Body { get; set; }

    [DisplayName("Deleted Date")]
    public required DateTime? DeletedDate {  get; set; }
}
