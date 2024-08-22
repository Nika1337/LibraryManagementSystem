

namespace Nika1337.Library.Presentation.Models.Reports;

public class ReportViewModel
{
    public string Title { get; set; } = "Report";
    public required string[] ColumnNames { get; set; }
    public required string[][] Content { get; set; }
}
