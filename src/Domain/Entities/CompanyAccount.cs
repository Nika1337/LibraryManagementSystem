namespace Nika1337.Library.Domain.Entities;
public class CompanyAccount : Account
{
    public required string CompanyName { get; set; }
    public string? WebsiteAddress { get; set; }
}
