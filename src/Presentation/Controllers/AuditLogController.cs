using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Operations Manager")]
[Route("Operations/AuditLogs")]
public class AuditLogController : Controller
{
    private readonly IAuditLogService _auditLogService;
    private readonly Dictionary<string, SortOption<AuditLog>> _sortOptions =
        new()
        {
            { "timestamp", new("Timestamp: Ascending", log => log.Timestamp) },
            { "timestampDesc",new( "Timestamp: Descending", log => log.Timestamp, true) },
        };
    private readonly string[] _applicationNames = ["Library", "Identity"];
    private readonly string[] _actions = ["Added", "Modified"];

    public AuditLogController(IAuditLogService auditLogService)
    {
        _auditLogService = auditLogService;
    }

    [HttpGet("SortOptions")]
    public IActionResult GetSortOptions()
    {
        var sortOptions = _sortOptions.Select(kvp => new
        {
            kvp.Key,
            Value = kvp.Value.DisplayString
        }).ToArray();

        return Ok(sortOptions);
    }

    [HttpGet]
    public async Task<IActionResult> AuditLogs(
             [FromQuery] int pageNumber = 1,
             [FromQuery] int pageSize = 10,
             [FromQuery] string? searchTerm = null,
             [FromQuery] string? orderBy = null,
             [FromQuery] bool isDescending = false,
             [FromQuery] DateTime? startTime = null,
             [FromQuery] DateTime? endTime = null,
             [FromQuery] string[]? applicationNames = null,
             [FromQuery] string[]? actions = null)
    {
        var sortOption = orderBy == null ? null
            : _sortOptions[orderBy];

        var request = new AuditLogPagedRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SearchTerm = searchTerm,
            OrderBy = sortOption?.Selector,
            IsDescending = isDescending,
            StartTime = startTime,
            EndTime = endTime,
            ApplicationNames = applicationNames,
            Actions = actions
        };

        var pagedLogs = await _auditLogService.GetPagedAuditLogsAsync(request);

        return View(pagedLogs);
    }

    [HttpGet("ApplicationNames")]
    public IActionResult GetApplicationNames()
    {
        return Ok(_applicationNames);
    }

    [HttpGet("Actions")]
    public IActionResult GetActions()
    {
        return Ok(_actions);
    }
}
