

namespace Nika1337.Library.Application.DataTransferObjects.Export;

public record ExcelExportRequest
{
    public required string[] ColumnNames { get; init; }
    public required string[][] Content { get; init; }
}
