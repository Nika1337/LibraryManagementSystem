

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Presentation.Models.Reports;
using System;
using System.Collections.Generic;

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
    public IActionResult GenerateReport(GenerateReportViewModel model)
    {
        Console.WriteLine(model.Subject);
        Console.WriteLine(model.Metric);
        Console.WriteLine(model.StartingMonth);
        Console.WriteLine(model.EndingMonth);
        throw new NotImplementedException();
    }
}
