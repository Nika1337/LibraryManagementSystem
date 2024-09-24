
using Microsoft.AspNetCore.Mvc;

namespace Nika1337.Library.Reporting;


[Route("Reports")]
[ApiController]
public class ReportsController : ControllerBase
{
    [HttpGet("Summary/{name}/{year:int}")]
    public async Task<IActionResult> GetPdfReport(string name, int year)
    {
        using var report = new LocalReport();


        // Traverse up to the root directory and then navigate to the Presentation folder
        var currentDir = Directory.GetCurrentDirectory(); // This will point to the web project's root
        var presentationFolder = Path.Combine(Directory.GetParent(currentDir).FullName, "Presentation"); // Adjust to the actual presentation folder name
        var reportPath = Path.Combine(presentationFolder, "Reports", "Designs", "PopularityReport.rdlc");

        report.ReportPath = reportPath;

        var parameters = new[]
        {
            new ReportParameter("popularityReportName", $"Popularity Report {year}"),
            new ReportParameter("companyName", "Library Management System"),
            new ReportParameter("topBooksTitle", $"Top Books in {year}"),
            new ReportParameter("topAuthorsTitle", $"Top Authors in {year}"),
            new ReportParameter("topAccountsTitle", $"Top Accounts in {year}"),
            new ReportParameter("topPublishersTitle", $"Top Publishers in {year}"),
            new ReportParameter("topGenresTitle", $"Top Genres in {year}"),
            new ReportParameter("topLanguagesTitle", $"Top Languages in {year}"),
        };

        report.SetParameters(parameters);

        // Create an instance of the strongly typed dataset
        var popularityReportDataSet = new PopularityReportDataSet();

        // Populate the DataTables with sample data
        PopulateSampleData(popularityReportDataSet.TopBooks, "Book");
        PopulateSampleData(popularityReportDataSet.TopAuthors, "Author");
        PopulateSampleData(popularityReportDataSet.TopAccounts, "Account");
        PopulateSampleData(popularityReportDataSet.TopPublishers, "Publisher");
        PopulateSampleData(popularityReportDataSet.TopGenres, "Genre");
        PopulateSampleData(popularityReportDataSet.TopLanguages, "Language");

        // Add the datasets to the report
        report.DataSources.Add(new ReportDataSource("TopBooks", popularityReportDataSet.TopBooks as DataTable));
        report.DataSources.Add(new ReportDataSource("TopAuthors", popularityReportDataSet.TopAuthors as DataTable));
        report.DataSources.Add(new ReportDataSource("TopAccounts", popularityReportDataSet.TopAccounts as DataTable));
        report.DataSources.Add(new ReportDataSource("TopPublishers", popularityReportDataSet.TopPublishers as DataTable));
        report.DataSources.Add(new ReportDataSource("TopGenres", popularityReportDataSet.TopGenres as DataTable));
        report.DataSources.Add(new ReportDataSource("TopLanguages", popularityReportDataSet.TopLanguages as DataTable));

        // Render the report (for example, as a PDF)
        var pdf = report.Render("PDF");

        MemoryStream ms = new(pdf);

        return new FileStreamResult(ms, "application/pdf");
    }

    private static void PopulateSampleData(DataTable table, string typeName)
    {
        // Add 10 entries
        for (int i = 1; i <= 10; i++)
        {
            var row = table.NewRow();
            row["Name"] = $"{typeName} {i}";
            row["Count"] = i * 10;
            table.Rows.Add(row);
        }

        // Add "Other" entry with aggregated count
        var otherRow = table.NewRow();
        otherRow["Name"] = "Other";
        otherRow["Count"] = 1000; // Total for all other items
        table.Rows.Add(otherRow);
    }
}
