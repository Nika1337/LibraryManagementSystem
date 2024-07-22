
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Checkouts;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.Checkouts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Consultant")]
[Route("Checkouts")]
public class CheckoutsController : BaseModelController<Checkout>
{
    private readonly ICheckoutService _checkoutService;
    private readonly IMapper _mapper;
    protected override Dictionary<string, SortOption<Checkout>> SortOptions =>
        new()
        {
            { "name", new("Account Name: A - Z", checkout => checkout.Account.AccountName) },
            { "nameDesc", new("Account Name: Z - A", checkout => checkout.Account.AccountName, true) },
            { "checkoutTime", new("Checkout Time: Ascending", checkout => checkout.CheckoutTime) },
            { "checkoutTimeDesc", new("Checkout Time: Descending", checkout => checkout.CheckoutTime, true) },
            { "returnTime", new("Supposed Return Time: Ascending", checkout => checkout.SupposedReturnTime) },
            { "returnTimeDesc", new("Supposed Return Time: Descending", checkout => checkout.SupposedReturnTime, true) },
        };

    public CheckoutsController(
        IMapper mapper,
        ICheckoutService service) : base(service)
    {
        _checkoutService = service;
        _mapper = mapper;
    }

    [HttpGet(Name = "Checkouts")]
    public async Task<IActionResult> Checkouts(
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null,
        string? sortField = null,
        bool doNotIncludeDeleted = false)
    {
        var request = ConstructBaseModelPagedRequest(pageNumber, pageSize, searchTerm, sortField, !doNotIncludeDeleted);

        var checkouts = await _checkoutService.GetPagedCheckoutsAsync(request);

        var model = _mapper.Map<PagedList<CheckoutPreviewViewModel>>(checkouts);

        return View(model);
    }

    [HttpGet("[action]")]
    public IActionResult AddCheckout()
    {
        var model = new CheckoutCreateViewModel();

        return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddCheckout(CheckoutCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var request = _mapper.Map<CheckoutCreateRequest>(model);

        try
        {
            await _checkoutService.CreateCheckoutAsync(request);
        }
        catch (NotEnoughBookCopiesException e)
        {
            model.ErrorMessage = e.Message;
            return View(model);
        }

        return RedirectToAction(nameof(Checkouts));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Checkouts(int id)
    {
        var checkout = await _checkoutService.GetCheckoutAsync(id);

        var model = _mapper.Map<CheckoutDetailedViewModel>(checkout);

        return View("Checkout", model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> Checkouts(CheckoutDetailedViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Checkout", model);
        }

        var request = _mapper.Map<CheckoutCloseRequest>(model);

        try
        {
            await _checkoutService.CloseCheckoutAsync(request);
        }
        catch (CheckoutCopiesMisMatchException e)
        {
            model.ErrorMessage = e.Message;
            return View("Checkout", model);
        }
        catch (CheckoutAlreadyClosedException)
        {
            model.ErrorMessage = "Checkout is already closed!";
            return View("Checkout", model);
        }

        return RedirectToRoute("Checkouts");
    }
}
