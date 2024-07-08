using Nika1337.Library.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Presentation.Models;
public class SortOption<T>(string displayString, Expression<Func<T, object?>> selector, bool isDescending = false)
{
    public string DisplayString => displayString;
    public Expression<Func<T, object?>> Selector => selector;
    public bool IsDescending => isDescending;
}
