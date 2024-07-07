

namespace Nika1337.Library.Domain.RequestFeatures;

public record MetaData
{
    public required int CurrentPage { get; set; }
    public required int TotalPages { get; set; }
    public required int PageSize { get; set; }
    public required int TotalCount { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}
