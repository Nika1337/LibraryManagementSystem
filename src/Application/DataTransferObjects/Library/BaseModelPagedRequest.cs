

using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Application.DataTransferObjects.Library;

public record BaseModelPagedRequest<T> : PagedRequest<T> where T : BaseModel
{
    public bool ShouldIncludeDeleted { get; init; } = true;
}
