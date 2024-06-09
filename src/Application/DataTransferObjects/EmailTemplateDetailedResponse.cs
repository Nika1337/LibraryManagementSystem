
using System;

namespace Nika1337.Library.Application.DataTransferObjects;
public record EmailTemplateDetailedResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string BriefDescription { get; init; }
    public required string Subject { get; init; }
    public required string Separator { get; init; }
    public required string Body { get; init; }
    public required string FromEmail { get; init; }
    public required DateTime? DeletedDate { get; init; }
}
