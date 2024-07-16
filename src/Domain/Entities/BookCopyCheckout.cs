

using System;

namespace Nika1337.Library.Domain.Entities;

public class BookCopyCheckout
{
    public required BookCopy BookCopy { get; set; }
    public required Checkout Checkout { get; set; }
    public BookCopyCheckoutStatus BookCopyCheckoutStatus { get; set; }
    public DateTime? BookCopyCheckoutCloseTime { get; set; }
}

public enum BookCopyCheckoutStatus
{
    BookCopyLostByCustomer,
    BookCopyReturned,
    BookCopyReturnedDamaged
}
