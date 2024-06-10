using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Presentation.Models.Operations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;


[Authorize(Roles = "Operations Manager")]
[Route("Operations/EmailTemplates")]
public class EmailTemplatesController : Controller
{
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IMapper _mapper;

    public EmailTemplatesController(IEmailTemplateService emailTemplateService, IMapper mapper)
    {
        _emailTemplateService = emailTemplateService;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> EmailTemplates(int id)
    {

        var selectedEmailTemplate = await _emailTemplateService.GetEmailTemplateAsync(id);

        var selectedDetailedEmailTemplate = _mapper.Map<DetailedEmailTemplateViewModel>(selectedEmailTemplate);

        var emailTemplates = await GetEmailTemplates();

        var model = new EmailTemplateViewModel
        {
            EmailTemplates = emailTemplates,
            SelectedEmailTemplate = selectedDetailedEmailTemplate
        };


        return View(model);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EmailTemplates(EmailTemplateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.EmailTemplates = await GetEmailTemplates();
            return View(model);
        }

        var updateRequest = _mapper.Map<EmailTemplateUpdateRequest>(model.SelectedEmailTemplate);

        try
        {
            await _emailTemplateService.UpdateEmailTemplateAsync(updateRequest);
        }
        catch(DuplicateException)
        {
            model.ErrorMessage = $"Email template with name '{model.SelectedEmailTemplate.Name}' already exists";
            model.EmailTemplates = await GetEmailTemplates();
            return View(model);
        }

        return RedirectToAction(nameof(EmailTemplates));
    }

    [HttpPost("[action]/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteEmailTemplate(int id)
    {
        await _emailTemplateService.DeleteEmailTemplateAsync(id);

        return Ok();
    }


    [HttpPost("[action]/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RenewEmailTemplate(int id)
    {
        await _emailTemplateService.RenewEmailTemplateAsync(id);

        return Ok();
    }



    private async Task<IEnumerable<SimpleEmailTemplateViewModel>> GetEmailTemplates()
    {
        var emailTemplates = await _emailTemplateService.GetAllEmailTemplatesAsync();

        var emailTemplateModels = _mapper.Map<IEnumerable<SimpleEmailTemplateViewModel>>(emailTemplates);

        return emailTemplateModels;
    }
}
