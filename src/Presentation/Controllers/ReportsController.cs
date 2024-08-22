

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Reports;
using Nika1337.Library.Presentation.Models.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;



[Authorize(Roles = "Operations Manager")]
[Route("Reports")]
public class ReportsController : Controller
{
    private readonly static Dictionary<string, string[]> SubjectsWithMetrics = new()
    {
        { "Books", ["Popularity", "Lost Count"] },
        { "Accounts", ["Books Taken", "Books Lost Or Destroyed", "Checkouts Completed"] },
        { "Publishers", ["Popularity"] },
        { "Genres", ["Popularity"] },
        { "Languages", ["Popularity"] },
        { "Authors", ["Popularity"] }
    };

    private readonly IReportService _reportService;
    private readonly IMapper _mapper;
    private readonly IExportService _exportService;

    public ReportsController(
        IReportService reportService,
        IMapper mapper,
        IExportService exportService)
    {
        _reportService = reportService;
        _mapper = mapper;
        _exportService = exportService;
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

    [HttpPost]
    public async Task<IActionResult> GenerateReportAsync(GenerateReportViewModel model)
    {
        var request = new AnnualReportRequest
        {
            Subject = model.Subject,
            Metric = model.Metric,
            Year = model.Year
        };

        var response = await _reportService.GenerateAnnualReportAsync(request);

        var newModel = _mapper.Map<ReportViewModel>(response);

        newModel.Title = $"{model.Subject} By {model.Metric} in {model.Year} Report";

        return View("Report", newModel);
    }
}
