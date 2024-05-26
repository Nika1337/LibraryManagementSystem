using System;

namespace Nika1337.Library.ApplicationCore.Entities;

public abstract class Account : BaseModel
{
    public required string AccountName { get; set; }
    public DateTime AccountCreationDate { get; set; }
    public required ContactInformation ContactInformation { get; set; }
}
