using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Account;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Consultant")]
[Route("Accounts")]
public class AccountsController : BaseModelController<Account>
{
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;
    protected override Dictionary<string, SortOption<Account>> SortOptions =>
        new()
        {
            { "name", new("Account Name: A - Z", account => account.AccountName) },
            { "nameDesc", new("Account Name: Z - A", account => account.AccountName, true) },
            { "creationDate", new("Creation Date: Ascending", account => account.AccountCreationDate) },
            { "creationDateDesc", new("Creation Date: Descending", account => account.AccountCreationDate, true)},
        };
    public AccountsController(
        IMapper mapper,
        IAccountService service) : base(service)
    {
        _mapper = mapper;
        _accountService = service;
    }

    [HttpGet(Name = "Accounts")]
    public async Task<IActionResult> Accounts(
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null,
        string? sortField = null,
        bool doNotIncludeDeleted = false)
    {
        var request = ConstructBaseModelPagedRequest(pageNumber, pageSize, searchTerm, sortField, !doNotIncludeDeleted);

        var accounts = await _accountService.GetPagedAccountsAsync(request);

        var model = _mapper.Map<PagedList<AccountPreviewViewModel>>(accounts);

        return View(model);
    }

    [HttpGet("[action]")]
    public IActionResult AddAccount()
    {
        var model = new AccountCreateViewModel();

        return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddAccount(AccountCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var request = _mapper.Map<AccountCreateRequest>(model);

        try
        {
            await _accountService.CreateAccountAsync(request);
        }
        catch (NameDuplicateException)
        {
            model.ErrorMessage = $"Account with Name '{model.AccountName}' already exists";
            return View(model);
        }
        catch (DuplicateException)
        {
            model.ErrorMessage = $"Account with identification '{model.CustomerIdentification}' already exists";
            return View(model);
        }

        return RedirectToAction(nameof(Accounts));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Accounts(int id)
    {
        var account = await _accountService.GetAccountAsync(id);

        var model = _mapper.Map<AccountDetailedViewModel>(account);

        return View("Account", model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> Accounts(AccountDetailedViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Account", model);
        }

        var request = _mapper.Map<AccountUpdateRequest>(model);

        try
        {
            await _accountService.UpdateAccountAsync(request);
        }
        catch (NameDuplicateException)
        {
            model.ErrorMessage = $"Account with Name '{model.AccountName}' already exists";
            return View(model);
        }
        catch (DuplicateException)
        {
            model.ErrorMessage = $"Account with identification '{model.CustomerIdentification}' already exists";
            return View(model);
        }

        return RedirectToRoute("Accounts");
    }

}
