

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Reports;
using Nika1337.Library.Presentation.Models.Reports;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;



[Authorize(Roles = "Operations Manager")]
[Route("Reports")]
public class ReportsController : Controller
{
    private readonly static Dictionary<string, string[]> SubjectsWithMetrics = new()
    {
        { "Books", ["Popularity", "Lost Or Destroyed"] },
        { "Accounts", ["Books Taken", "Books Lost Or Destroyed", "Checkouts Completed"] },
        { "Publishers", ["Popularity"] },
        { "Genres", ["Popularity"] },
        { "Languages", ["Popularity"] },
        { "Authors", ["Popularity"] }
    };

    private readonly IReportService _reportService;
    private readonly IMapper _mapper;

    public ReportsController(
        IReportService reportService,
        IMapper mapper)
    {
        _reportService = reportService;
        _mapper = mapper;
    }

    [HttpGet("SubjectsWithMetrics")]
    public IActionResult GetAllSubjectsWithMetrics()
    {
        return Json(SubjectsWithMetrics);
    }

    [HttpGet]
    public IActionResult GenerateReport()
    {
        var model = new GenerateReportViewModel();
        return View(model);
    }

    [HttpGet("{subject}/{metric}/{year:int}")]
    public async Task<IActionResult> GetReport(string subject, string metric, int year)
    {
        var request = new AnnualReportRequest
        {
            Subject = subject,
            Metric = metric,
            Year = year
        };

        var response = await _reportService.GenerateAnnualReportAsync(request);

        var newModel = _mapper.Map<ReportViewModel>(response);
        newModel.Title = $"{subject} By {metric} in {year} Report";

        return View("Report", newModel);
    }
}
