namespace Nika1337.Library.ApplicationCore.Entities;
public class CompanyAccount : Account
{
    public required string CompanyName { get; set; }
    public string? WebsiteAddress { get; set; }
}
