using System.Collections.Generic;

namespace Nika1337.Library.Presentation.Models.Operations;

public class EmailTemplateViewModel
{
    public IEnumerable<SimpleEmailTemplateViewModel> EmailTemplates { get; set; } = [];
    public DetailedEmailTemplateViewModel SelectedEmailTemplate { get; set; }
    public string? ErrorMessage { get; set; }
}
