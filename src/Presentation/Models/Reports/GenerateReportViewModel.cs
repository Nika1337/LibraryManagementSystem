using System.Collections.Generic;

namespace Nika1337.Library.Presentation.Models.Reports;

public class GenerateReportViewModel
{
    public required Dictionary<string, string[]> SubjectsWithMetrics { get; init; }
    public required string[] ReportNames { get; init; }
    public required int[] AvaliableYears { get; init; }
}
