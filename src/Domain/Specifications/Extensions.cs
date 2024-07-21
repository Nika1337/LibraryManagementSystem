using Nika1337.Library.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications;

internal static class Extensions
{
    internal static Expression<Func<Book, bool>> IsBookAvaliable => book => 
        book.DeletedDate == null
        && book.Editions.AsQueryable().Any(IsBookEditionAvaliable);

    internal static Expression<Func<BookEdition, bool>> IsBookEditionAvaliable => bookEdition =>
        bookEdition.DeletedDate == null
        && bookEdition.Copies.AsQueryable().Any(IsBookCopyAvaliable);

    internal static Expression<Func<BookCopy, bool>> IsBookCopyAvaliable => bookCopy =>
        bookCopy.DeletedDate == null
        && bookCopy.BookCopyCheckouts.All(bcc =>
            bcc.BookCopyCheckoutCloseTime != null
                && (bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturned || bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturnedDamaged)
            || bcc.Checkout.DeletedDate != null
        );

    internal static Expression<Func<BookCopy, bool>> ShouldIncludeBookCopyInTotal => bookCopy =>
        bookCopy.DeletedDate == null
        && bookCopy.BookCopyCheckouts.All(bcc =>
            bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturned
                || bcc.BookCopyCheckoutStatus == BookCopyCheckoutStatus.BookCopyReturnedDamaged
                || bcc.BookCopyCheckoutStatus == null
            || bcc.Checkout.DeletedDate != null
        );
}
