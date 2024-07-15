

namespace Nika1337.Library.Application.DataTransferObjects.Library.Account.Company;

public record CompanyAccountCreateRequest : AccountCreateRequest
{
    public required string CompanyName { get; init; }
    public required string? WebsiteAddress { get; init; }
}
