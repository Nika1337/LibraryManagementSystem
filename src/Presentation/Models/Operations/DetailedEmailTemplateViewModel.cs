

using System;

namespace Nika1337.Library.Presentation.Models.Operations;

public class DetailedEmailTemplateViewModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string BriefDescription { get; set; }
    public required string Subject { get; set; }
    public required string FromEmail { get; set; }
    public required string Body { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime LastUpdatedDate {  get; set; }
    public required DateTime? DeletedDate {  get; set; }
}
