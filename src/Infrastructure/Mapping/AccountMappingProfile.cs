using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Account;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Accounts.Results;
using System;
using System.Linq;

namespace Nika1337.Library.Infrastructure.Mapping;

public class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<AccountCreateRequest, Account>()
            .ForMember(ac => ac.AccountCreationDate, opts => opts.MapFrom(acr => DateTime.Now));

        CreateMap<AccountUpdateRequest, Account>();

        CreateMap<Account, AccountDetailedResponse>()
            .ForMember(adr => adr.ActiveCheckouts, opts => opts.MapFrom(ac => GetActiveCheckoutsCount(ac)))
            .ForMember(adr => adr.TotalCheckouts, opts => opts.MapFrom(ac => ac.Checkouts.Count()));

        CreateMap<AccountPreviewResult, AccountPreviewResponse>();

        CreateMap<Account, PrimitiveResponse>()
            .ForMember(apr => apr.Name, opts => opts.MapFrom(ac => ac.AccountName));

    }

    private static int GetActiveCheckoutsCount(Account account)
    {
        return account.Checkouts.Count(c => c.BookCopyCheckouts.Any(bcc => bcc.BookCopyCheckoutCloseTime == null));
    }
}
