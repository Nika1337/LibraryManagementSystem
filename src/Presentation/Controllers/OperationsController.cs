using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Exceptions;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;


[Authorize(Roles = "Operations Manager")]
public class OperationsController : Controller
{
    private readonly IEmailTemplateService _emailTemplateService;

    public OperationsController(IEmailTemplateService emailTemplateService)
    {
        _emailTemplateService = emailTemplateService;
    }

    [HttpGet]
    public async Task<IActionResult> EmailTemplates(int? id)
    {

        var emailTemplates = await GetEmailTemplates();

        var selectedEmailTemplateId = id ?? emailTemplates.First().Id;

        var selectedEmailTemplate = await _emailTemplateService.GetEmailTemplateByIdAsync(selectedEmailTemplateId);

        var selectedDetailedEmailTemplate =
            new DetailedEmailTemplateViewModel { 
                Id = selectedEmailTemplate.Id,
                Name = selectedEmailTemplate.Name,
                BriefDescription = selectedEmailTemplate.BriefDescription,
                Subject = selectedEmailTemplate.Subject,
                FromEmail = selectedEmailTemplate.FromEmail,
                Separator = selectedEmailTemplate.Separator,
                Body = selectedEmailTemplate.Body,
                CreationDate = selectedEmailTemplate.CreationDate,
                LastUpdatedDate = selectedEmailTemplate.LastUpdatedDate,
                DeletedDate = selectedEmailTemplate.DeletedDate
            };


        var model = new EmailTemplateViewModel
        {
            EmailTemplates = emailTemplates,
            SelectedEmailTemplate = selectedDetailedEmailTemplate
        };


        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EmailTemplates(EmailTemplateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.EmailTemplates = await GetEmailTemplates();
            return View(model);
        }

        var existingTemplate = await _emailTemplateService.GetEmailTemplateByIdAsync(model.SelectedEmailTemplate.Id);

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

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("[controller]/[action]/{templateId:int}")]
    public async Task<IActionResult> DeleteEmailTemplate(int templateId)
    {
        await _emailTemplateService.DeleteEmailTemplateAsync(templateId);

        return Ok();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("[controller]/[action]/{templateId:int}")]
    public async Task<IActionResult> RenewEmailTemplate(int templateId)
    {
        await _emailTemplateService.RenewEmailTemplateAsync(templateId);

        return Ok();
    }



    private async Task<IEnumerable<SimpleEmailTemplateViewModel>> GetEmailTemplates()
    {
        var emailTemplates = await _emailTemplateService.GetAllActiveEmailTemplatesAsync();
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
