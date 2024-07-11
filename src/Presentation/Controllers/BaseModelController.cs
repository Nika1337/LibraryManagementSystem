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

    protected readonly FilterOption[] _filterOptions =
        [
            new BoolFilterOption {
                Name = "Do Not Include Deleted"
            }
        ];
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

    [HttpGet("FilterOptions")]
    public virtual IActionResult GetFilterOptions()
    {
        var filterOptions = _filterOptions.Select(option => option.ToJsonString());

        return Ok(filterOptions);
    }

    protected BaseModelPagedRequest<T> ConstructBaseModelPagedRequest(int pageNumber, int pageSize, string? searchTerm, string? sortField, bool shouldIncludeDeleted)
    {
        var sortOptions = sortField == null ? null : SortOptions[sortField];

        Expression<Func<T, object?>>? orderBy = sortOptions?.Selector;
        bool isDescending = sortOptions?.IsDescending ?? false;


        return new BaseModelPagedRequest<T>
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
