using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Nika1337.Library.Presentation.Controllers;

public abstract class BaseModelController<T> : Controller where T : BaseModel
{
    private readonly IBaseModelService _service;
    protected abstract Dictionary<string, SortOption<T>> SortOptions { get; }
    protected BaseModelController(IBaseModelService service)
    {
        _service = service;
    }


    [HttpPost("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return Ok();
    }

    [HttpPost("Renew/{id:int}")]
    public async Task<IActionResult> Renew(int id)
    {
        await _service.RenewAsync(id);

        return Ok();
    }

    [HttpGet("SortOptions")]
    public IActionResult GetSortOptions()
    {
        var sortOptions = SortOptions.Select(kvp => new
        {
            kvp.Key,
            Value = kvp.Value.DisplayString
        }).ToArray();

        return Ok(sortOptions);
    }

    protected PagedRequest<T> ConstructBaseModelPagedRequest(int pageNumber, int pageSize, string? searchTerm, string? sortField, bool shouldIncludeDeleted)
    {
        var sortOptions = sortField == null ? null : SortOptions[sortField];

        Expression<Func<T, object?>>? orderBy = sortOptions?.Selector;
        bool isDescending = sortOptions?.IsDescending ?? false;


        return new PagedRequest<T>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SearchTerm = searchTerm,
            OrderBy = orderBy,
            IsDescending = isDescending,
            ShouldIncludeDeleted = shouldIncludeDeleted
        };
    }
}
