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

        CreateMap<AccountDetailedResult, AccountDetailedResponse>();

        CreateMap<AccountResult, AccountPreviewResponse>();

        CreateMap<Account, PrimitiveResponse>()
            .ForMember(apr => apr.Name, opts => opts.MapFrom(ac => ac.AccountName));

    }
}
