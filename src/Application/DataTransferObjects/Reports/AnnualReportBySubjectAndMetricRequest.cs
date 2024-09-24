

namespace Nika1337.Library.Application.DataTransferObjects.Reports;

public record AnnualReportBySubjectAndMetricRequest : AnnualReportRequest
{
    public required string Subject { get; init; }
    public required string Metric { get; init; }
}
