

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Reports;

public class GenerateReportViewModel
{
    [Required(ErrorMessage = "Please Specify the Subject")]
    public string Subject { get; set; }

    [Required(ErrorMessage = "Please Specify the Metric")]
    public string Metric { get; set; }

    [Required(ErrorMessage = "Please Specify Starting Month")]
    [DisplayName("Starting Month")]
    public DateTime StartingMonth { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Please Specify Ending Month")]
    [DisplayName("Ending Month")]
    public DateTime EndingMonth { get; set; } = DateTime.Now;
}
