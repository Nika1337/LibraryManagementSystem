

namespace Nika1337.Library.Domain.Entities;

public class ContactInformation
{
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required Address Address { get; set; }
}