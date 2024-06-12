using System;

namespace Nika1337.Library.Domain.Entities;
public class Checkout : BaseModel
{
    public required Account Account { get; set; }
    public required BookCopy BookCopy { get; set; }
    public required DateTime CheckoutTime { get; set; }
    public required DateTime SupposedReturnTime { get; set; }
    public DateTime? CheckoutCloseTime { get; set; }
    public CheckoutStatus CheckoutStatus { get; set; }
}

public enum CheckoutStatus
{
    BookCopyLostByCustomer,
    BookCopyReturned,
    BookCopyReturnedDamaged
}