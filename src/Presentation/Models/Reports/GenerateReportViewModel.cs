

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


    [Required(ErrorMessage = "Please Specify Year")]
    [DisplayName("Year")]
    [Range(minimum: 1900, maximum: 2100)]
    public int Year { get; set; } = DateTime.Now.Year;
}
