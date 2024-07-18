

using Nika1337.Library.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

internal static class Extensions
{
    internal static Expression<Func<BookCopy, bool>> IsAvaliable => bookCopy =>
        bookCopy.BookCopyCondition == BookCopyCondition.Usable &&
        bookCopy.BookCopyCheckouts.All(bcc => bcc.BookCopyCheckoutCloseTime != null);
}
