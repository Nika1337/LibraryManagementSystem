

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Reports;
using Nika1337.Library.Presentation.Models.Reports;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;



[Authorize(Roles = "Operations Manager")]
[Route("Reports")]
public class ReportsController : Controller
{
    private readonly static Dictionary<string, string[]> _subjectsWithMetrics = new()
    {
        { "Books", ["Popularity", "Lost Or Destroyed"] },
        { "Accounts", ["Copies Taken", "Copies Lost Or Destroyed", "Checkouts Completed"] },
        { "Publishers", ["Popularity"] },
        { "Genres", ["Popularity"] },
        { "Languages", ["Popularity"] },
        { "Authors", ["Popularity"] }
    };

    private readonly string[] _reportNames = ["Popularity"];

    private readonly IReportDataSource _reportDataSource;
    private readonly IMapper _mapper;

    public ReportsController(
        IReportDataSource reportDataSource,
        IMapper mapper)
    {
        _reportDataSource = reportDataSource;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GenerateReport()
    {
        var model = new GenerateReportViewModel
        {
            SubjectsWithMetrics = _subjectsWithMetrics,
            ReportNames = _reportNames,
            AvaliableYears = [2024]
        };
        return View(model);
    }

    [HttpGet("{subject}/{metric}/{year:int}")]
    public async Task<IActionResult> GetAnnualHTMLReport(string subject, string metric, int year)
    {
        var request = new AnnualReportBySubjectAndMetricRequest
        {
            Subject = subject,
            Metric = metric,
            Year = year
        };

        var response = await _reportDataSource.GetAnnualReportTableAsync(request);

        var newModel = _mapper.Map<ReportViewModel>(response);
        newModel.Title = $"{subject} By {metric} in {year} Report";

        return View("Report", newModel);
    }


    [HttpGet("Popularity/{year:int}")]
    public async Task<IActionResult> GetPopularityReportAsync(int year)
    {
        using var report = new LocalReport();

        SetPopularityReportPath(report);

        PopulatePopularityReportParameters(report, year);

        await PopulatePopularityReportData(report, year);

        var pdf = report.Render("PDF");

        MemoryStream ms = new(pdf);

        return new FileStreamResult(ms, "application/pdf");
    }

    private async Task PopulatePopularityReportData(LocalReport report, int year)
    {
        var request = new AnnualReportRequest { Year = year };

        var popularityDataSet = await _reportDataSource.GetPopularityReportDataSetAsync(request);

        foreach (var table in popularityDataSet.Tables)
        {
            var dataTable = (DataTable)table;
            report.DataSources.Add(new ReportDataSource(dataTable.TableName, dataTable));
        }
    }

    private static void SetPopularityReportPath(LocalReport report)
    {
        var currentDir = Directory.GetCurrentDirectory();
        var presentationFolder = Path.Combine(Directory.GetParent(currentDir)!.FullName, "Presentation");
        var reportPath = Path.Combine(presentationFolder, "Reports", "Designs", "PopularityReport.rdlc");

        report.ReportPath = reportPath;
    }
    private static void PopulatePopularityReportParameters(LocalReport report, int year)
    {
        var parameters = new[]
        {
            new ReportParameter("popularityReportName", $"Popularity Report {year}"),
            new ReportParameter("companyName", "Library Management System"),
            new ReportParameter("topBooksTitle", $"Top books by popularity"),
            new ReportParameter("topAuthorsTitle", $"Top authors by popularity"),
            new ReportParameter("topAccountsTitle", $"Top accounts by copies taken"),
            new ReportParameter("topPublishersTitle", $"Top publishers by popularity"),
            new ReportParameter("topGenresTitle", $"Top genres by popularity"),
            new ReportParameter("topLanguagesTitle", $"Top languages by popularity"),
        };

        report.SetParameters(parameters);
    }
}
