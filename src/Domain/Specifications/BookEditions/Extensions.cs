

using Nika1337.Library.Domain.Entities;
using System.Linq;

namespace Nika1337.Library.Domain.Specifications.BookEditions;

internal static class Extensions
{

    internal static bool IsAvaliable(this BookCopy bookCopy)
    {
        var isCopyLentOut = bookCopy.BookCopyCheckouts.Any(bcc => bcc.BookCopyCheckoutCloseTime == null);

        var isCopyUsable = bookCopy.BookCopyCondition == BookCopyCondition.Usable;

        return !isCopyLentOut && isCopyUsable;
    }
}
