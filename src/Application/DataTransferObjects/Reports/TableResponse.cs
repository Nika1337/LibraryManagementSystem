

namespace Nika1337.Library.Application.DataTransferObjects.Reports;

public record TableResponse
{
    public required string[] ColumnNames { get; init; }
    public required string[][] Content { get; init; }
}
