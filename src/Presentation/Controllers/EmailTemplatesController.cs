using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Presentation.Models.EmailTemplates;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;


[Authorize(Roles = "Operations Manager")]
[Route("Operations/EmailTemplates")]
public class EmailTemplatesController : BaseModelController
{
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IMapper _mapper;

    public EmailTemplatesController(
        IEmailTemplateService emailTemplateService, 
        IMapper mapper) : base(emailTemplateService)
    {
        _emailTemplateService = emailTemplateService;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> EmailTemplates(int id)
    {

        var selectedEmailTemplate = await _emailTemplateService.GetEmailTemplateAsync(id);

        var model = _mapper.Map<EmailTemplateViewModel>(selectedEmailTemplate);
     

        return View(model);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EmailTemplates(EmailTemplateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var updateRequest = _mapper.Map<EmailTemplateUpdateRequest>(model);

        try
        {
            await _emailTemplateService.UpdateEmailTemplateAsync(updateRequest);
        }
        catch(NameDuplicateException)
        {
            model.ErrorMessage = $"Email template with name '{model.Name}' already exists";
            return View(model);
        }

        return RedirectToAction(nameof(EmailTemplates));
    }

    [HttpGet]
    public async Task<IActionResult> GetEmailTemplates()
    {
        var emailTemplates = await _emailTemplateService.GetAllEmailTemplatesAsync();


        return Json(emailTemplates);
    }
}
