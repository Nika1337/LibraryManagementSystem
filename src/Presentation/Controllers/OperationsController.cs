using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.Operations;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

public class OperationsController : Controller
{
    private readonly IEmailTemplateService _emailTemplateService;

    public OperationsController(IEmailTemplateService emailTemplateService)
    {
        _emailTemplateService = emailTemplateService;
    }

    public async Task<IActionResult> EmailTemplates(int? id)
    {
        var emailTemplates = await _emailTemplateService.GetAllActiveEmailTemplatesAsync();
        var simpleEmailTemplates = emailTemplates.Select(
            et => new SimpleEmailTemplateViewModel
            {
                Id = et.Id,
                Name = et.Name,
                BriefDescription = et.BriefDescription,
                IsActive = et.DeletedDate != null
            });

        var selectedEmailTemplate = id.HasValue ? await _emailTemplateService.GetEmailTemplateByIdAsync(id.Value) : null;

        var selectedDetailedEmailTemplate =
            selectedEmailTemplate is null ? null :
            new DetailedEmailTemplateViewModel { 
                Id = selectedEmailTemplate.Id,
                Name = selectedEmailTemplate.Name,
                BriefDescription = selectedEmailTemplate.BriefDescription,
                Subject = selectedEmailTemplate.Subject,
                FromEmail = selectedEmailTemplate.FromEmail,
                Body = selectedEmailTemplate.Body,
                CreatedDate = selectedEmailTemplate.CreationDate,
                LastUpdatedDate = selectedEmailTemplate.LastUpdatedDate,
                DeletedDate = selectedEmailTemplate.DeletedDate
            };


        var model = new EmailTemplateViewModel
        {
            EmailTemplates = simpleEmailTemplates,
            SelectedEmailTemplate = selectedDetailedEmailTemplate
        };

        return View(model);
    }
}
