using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Validation.Date;

public static class DateValidator
{
    public static ValidationResult? ValidateDateOfBirth(DateTime dateOfBirth, ValidationContext context)
    {
        var minDate = new DateTime(1900, 1, 1);
        var maxDate = DateTime.Now;

        if (dateOfBirth < minDate)
        {
            return new ValidationResult($"Date of Birth cannot be earlier than {minDate.ToShortDateString()}.");
        }

        if (dateOfBirth > maxDate)
        {
            return new ValidationResult("Date of Birth cannot be in the future.");
        }

        return ValidationResult.Success;
    }
}
