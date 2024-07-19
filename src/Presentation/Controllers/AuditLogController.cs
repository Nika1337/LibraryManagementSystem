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
[Route("AuditLog")]
public class AuditLogController : Controller
{
    private readonly IAuditLogService _auditLogService;
    private readonly Dictionary<string, SortOption<AuditLog>> _sortOptions =
        new()
        {
            { "timestamp", new("Timestamp: Ascending", log => log.Timestamp) },
            { "timestampDesc", new( "Timestamp: Descending", log => log.Timestamp, true) },
        };

    private readonly FilterOption[] _filterOptions =
        [
            new RangeFilterOption {
                Name = "Timestamp",
                RangeFilterOptionType = RangeFilterOptionType.DateTime,
            },
            new ListFilterOption {
                Name = "Applications",
                Choices = ["Library", "Identity"]
            },
            new ListFilterOption {
                Name = "Actions",
                Choices = ["Added", "Modified", "Deleted"]
            }
        ];

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
             [FromQuery] string? sortField = null,
             [FromQuery] DateTime? timestampStart = null,
             [FromQuery] DateTime? timestampEnd = null,
             [FromQuery] string? applications = null,
             [FromQuery] string? actions = null)
    {
        var sortOption = sortField == null ? null
            : _sortOptions[sortField];

        var request = new AuditLogPagedRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SearchTerm = searchTerm,
            OrderBy = sortOption?.Selector,
            IsDescending = sortOption?.IsDescending ?? false,
            StartTime = timestampStart,
            EndTime = timestampEnd,
            ApplicationNames = applications?.Split(","),
            Actions = actions?.Split(",")
        };

        var pagedLogs = await _auditLogService.GetPagedAuditLogsAsync(request);

        return View(pagedLogs);
    }

    [HttpGet("FilterOptions")]
    public IActionResult GetFilterOptions()
    {
        var filterOptions = _filterOptions.Select(option => option.ToJsonString());

        return Ok(filterOptions);
    }


}
