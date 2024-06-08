using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Presentation.Models.Operations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;


[Authorize(Roles = "Operations Manager")]
[Route("Operations/EmailTemplates")]
public class EmailTemplatesController : Controller
{
    private readonly IEmailTemplateService _emailTemplateService;

    public EmailTemplatesController(IEmailTemplateService emailTemplateService)
    {
        _emailTemplateService = emailTemplateService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> EmailTemplates(int id)
    {

        var selectedEmailTemplate = await _emailTemplateService.GetEmailTemplateAsync(id);

        var emailTemplates = await GetEmailTemplates();

        var selectedDetailedEmailTemplate =
            new DetailedEmailTemplateViewModel { 
                Name = selectedEmailTemplate.Name,
                BriefDescription = selectedEmailTemplate.BriefDescription,
                Subject = selectedEmailTemplate.Subject,
                FromEmail = selectedEmailTemplate.FromEmail,
                Separator = selectedEmailTemplate.Separator,
                Body = selectedEmailTemplate.Body,
                DeletedDate = selectedEmailTemplate.DeletedDate
            };


        var model = new EmailTemplateViewModel
        {
            EmailTemplates = emailTemplates,
            SelectedEmailTemplate = selectedDetailedEmailTemplate
        };


        return View(model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> EmailTemplates(int id, EmailTemplateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.EmailTemplates = await GetEmailTemplates();
            return View(model);
        }

        var existingTemplate = await _emailTemplateService.GetEmailTemplateAsync(id);

        existingTemplate.Name = model.SelectedEmailTemplate.Name;
        existingTemplate.Subject = model.SelectedEmailTemplate.Subject;
        existingTemplate.FromEmail = model.SelectedEmailTemplate.FromEmail;
        existingTemplate.BriefDescription = model.SelectedEmailTemplate.BriefDescription;
        existingTemplate.Separator = model.SelectedEmailTemplate.Separator;
        existingTemplate.Body = model.SelectedEmailTemplate.Body;
 

        try
        {
            await _emailTemplateService.UpdateEmailTemplateAsync(existingTemplate);
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
        var emailTemplateModels = emailTemplates.Select(
            et => new SimpleEmailTemplateViewModel
            {
                Id = et.Id,
                Name = et.Name,
                BriefDescription = et.BriefDescription,
                IsActive = et.DeletedDate == null
            });
        return emailTemplateModels;
    }
}
