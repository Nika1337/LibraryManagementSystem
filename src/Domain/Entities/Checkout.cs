using System;
using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;
public class Checkout : BaseModel
{
    public required DateTime CheckoutTime { get; set; }
    public required DateTime SupposedReturnTime { get; set; }
    public required Account Account { get; set; }
    public required BookEdition BookEdition { get; set; }
    public List<BookCopyCheckout> BookCopyCheckouts { get; set; } = [];
}