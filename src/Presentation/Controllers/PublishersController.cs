using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Publishers;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.Publishers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;


[Authorize(Roles = "Core Librarian")]
[Route("Books/Publishers")]
public class PublishersController : BaseModelController<Publisher>
{
    private readonly IMapper _mapper;
    private readonly IPublisherService _publisherService;
    protected override Dictionary<string, SortOption<Publisher>> SortOptions =>
        new()
        {
            { "name", new("Name: A - Z", publisher => publisher.PublisherName) },
            { "nameDesc", new("Name: Z - A", publisher => publisher.PublisherName, true) },
            { "editionsCount", new("Editions Released Count: Ascending", publisher => publisher.PublishedBookEditions.Count) },
            { "editionsCountDesc", new("Editions Released Count: Descending", publisher => publisher.PublishedBookEditions.Count, true) },
        };

    public PublishersController(
        IMapper mapper,
        IPublisherService service) : base(service)
    {
        _mapper = mapper;
        _publisherService = service;
    }

    [HttpGet(Name = "Publishers")]
    public async Task<IActionResult> Publishers(
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null,
        string? sortField = null,
        bool doNotIncludeDeleted = false)
    {
        var request = ConstructBaseModelPagedRequest(pageNumber, pageSize, searchTerm, sortField, !doNotIncludeDeleted);

        var publishers = await _publisherService.GetPagedPublishersAsync(request);

        var model = _mapper.Map<PagedList<PublisherPreviewViewModel>>(publishers);

        return View(model);
    }

    [HttpGet("[action]")]
    public IActionResult AddPublisher()
    {
        var model = new PublisherCreateViewModel();

        return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddPublisher(PublisherCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var request = _mapper.Map<PublisherCreateRequest>(model);

        try
        {
            await _publisherService.CreatePublisherAsync(request);
        }
        catch (NameDuplicateException)
        {
            model.ErrorMessage = $"Publisher with Name '{model.PublisherName}' already exists";
            return View(model);
        }

        return RedirectToAction(nameof(Publishers));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Publishers(int id)
    {
        var publisher = await _publisherService.GetPublisherAsync(id);

        var model = _mapper.Map<PublisherDetailedViewModel>(publisher);

        return View("Publisher", model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> Publishers(PublisherDetailedViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Publisher", model);
        }

        var request = _mapper.Map<PublisherUpdateRequest>(model);

        try
        {
            await _publisherService.UpdatePublisherAsync(request);
        }
        catch (NameDuplicateException)
        {
            model.ErrorMessage = $"Publisher with Name '{model.PublisherName}' already exists";
            return View("Publisher", model);
        }

        return RedirectToRoute("Publishers");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetActivePublishers()
    {
        var publishers = await _publisherService.GetActivePublishersAsync();

        return Ok(publishers);
    }
}
