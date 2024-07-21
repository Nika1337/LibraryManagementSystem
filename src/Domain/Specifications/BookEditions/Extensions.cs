

using Nika1337.Library.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

internal static class Extensions
{
    internal static Expression<Func<BookCopy, bool>> IsAvaliable => bookCopy =>
        bookCopy.DeletedDate == null
        && bookCopy.BookCopyCheckouts.All(bcc =>
            (bcc.BookCopyCheckoutCloseTime != null
                && (bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturned || bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturnedDamaged))
            || bcc.Checkout.DeletedDate != null
        );

    internal static Expression<Func<BookCopy, bool>> ShouldIncludeInTotal => bookCopy =>
        bookCopy.DeletedDate == null
        && bookCopy.BookCopyCheckouts.All(bcc =>
            (bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturned
                || bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturnedDamaged
                || bcc.BookCopyCheckoutStatus == null)
            || bcc.Checkout.DeletedDate != null
        );
}
