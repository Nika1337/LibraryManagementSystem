﻿

namespace Nika1337.Library.Application.DataTransferObjects;
public record EmailTemplateSimpleResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string BriefDescription { get; init; }
    public required string Subject { get; init; }

    public required string FromEmail { get; init; }
    public required bool IsActive { get; init; }
}
