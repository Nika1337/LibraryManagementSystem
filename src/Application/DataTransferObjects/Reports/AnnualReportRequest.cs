
namespace Nika1337.Library.Application.DataTransferObjects.Reports;

public record AnnualReportRequest
{
    public required int Year { get; init; }
}
