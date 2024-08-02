using System;
using System.Collections.Generic;

namespace Nika1337.Library.Domain.Entities;

public class Account : BaseModel
{
    public required string AccountName { get; set; }
    public DateTime AccountCreationDate { get; set; }
    public required ContactInformation ContactInformation { get; set; }
    public required string CustomerIdentification { get; set; }
    public ICollection<Checkout> Checkouts { get; } = [];
}
