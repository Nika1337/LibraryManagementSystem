

using Nika1337.Library.Domain.Entities;
using System;

namespace Nika1337.Library.Application.DataTransferObjects;
public record AuditLogPagedRequest : PagedRequest<AuditLog>
{
    public DateTime? StartTime { get; init; } = null;
    public DateTime? EndTime { get; init; } = null;
    public string[]? ApplicationNames { get; init; } = null;
    public string[]? Actions { get; init; } = null;
}
