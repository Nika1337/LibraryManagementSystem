using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Account;
using Nika1337.Library.Domain.Entities;
using System;
using System.Linq;

namespace Nika1337.Library.Infrastructure.Mapping;

public class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<AccountCreateRequest, Account>()
            .ForMember(ac => ac.AccountCreationDate, opts => opts.MapFrom(acr => DateTime.UtcNow));

        CreateMap<AccountUpdateRequest, Account>();

        CreateMap<Account, AccountDetailedResponse>()
            .ForMember(adr => adr.ActiveCheckouts, opts => opts.MapFrom(ac => GetActiveCheckoutsCount(ac)))
            .ForMember(adr => adr.TotalCheckouts, opts => opts.MapFrom(ac => ac.Checkouts.Count()));

        CreateMap<Account, AccountPreviewResponse>()
            .ForMember(apr => apr.ActiveCheckouts, opts => opts.MapFrom(ac => GetActiveCheckoutsCount(ac)))
            .ForMember(apr => apr.TotalCheckouts, opts => opts.MapFrom(ac => ac.Checkouts.Count()))
            .ForMember(apr => apr.IsActive, opts => opts.MapFrom(ac => ac.DeletedDate == null));

        CreateMap<Account, AccountPrimitiveResponse>()
            .ForMember(apr => apr.Name, opts => opts.MapFrom(ac => ac.AccountName));

    }

    private static int GetActiveCheckoutsCount(Account account)
    {
        return account.Checkouts.Count(c => c.BookCopyCheckouts.Any(bcc => bcc.BookCopyCheckoutCloseTime == null));
    }
}
