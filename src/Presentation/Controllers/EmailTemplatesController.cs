using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.EmailTemplates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;


[Authorize(Roles = "Operations Manager")]
[Route("EmailTemplates")]
public class EmailTemplatesController : BaseModelController<EmailTemplate>
{
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IMapper _mapper;
    protected override Dictionary<string, SortOption<EmailTemplate>> SortOptions => [];

    public EmailTemplatesController(
        IEmailTemplateService emailTemplateService, 
        IMapper mapper) : base(emailTemplateService)
    {
        _emailTemplateService = emailTemplateService;
        _mapper = mapper;
    }

    [HttpGet(Name = "Email Templates")]
    public async Task<IActionResult> EmailTemplates()
    {
        var templates = await _emailTemplateService.GetAllEmailTemplatesAsync();

        var model = _mapper.Map<IEnumerable<EmailTemplatePreviewViewModel>>(templates);

        return View(model);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> EmailTemplates(int id)
    {
        var template = await _emailTemplateService.GetEmailTemplateAsync(id);

        var model = _mapper.Map<EmailTemplateDetailedViewModel>(template);
     
        return View("EmailTemplate", model);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EmailTemplates(EmailTemplateDetailedViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("EmailTemplate", model);
        }

        var updateRequest = _mapper.Map<EmailTemplateUpdateRequest>(model);

        try
        {
            await _emailTemplateService.UpdateEmailTemplateAsync(updateRequest);
        }
        catch (NameDuplicateException)
        {
            model.ErrorMessage = $"Email template with name '{model.Name}' already exists";
            return View("EmailTemplate", model);
        }

        return RedirectToRoute(routeName: "Email Templates");
    }
}
