using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Validation;

public class NotZeroAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) => (int)(value ?? 0) != 0;
}