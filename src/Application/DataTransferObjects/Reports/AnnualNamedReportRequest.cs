
namespace Nika1337.Library.Application.DataTransferObjects.Reports;

public record AnnualNamedReportRequest : AnnualReportRequest
{
    public required string Name { get; init; }
}
