using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Account;
using Nika1337.Library.Presentation.Models.Accounts;

namespace Nika1337.Library.Presentation.Mapping;

public class AccountViewModelMappingProfile : Profile
{
    public AccountViewModelMappingProfile()
    {
        CreateMap<AccountDetailedViewModel, AccountUpdateRequest>();

        CreateMap<AccountDetailedResponse, AccountDetailedViewModel>();

        CreateMap<AccountPreviewResponse, AccountPreviewViewModel>();

        CreateMap<AccountCreateViewModel, AccountCreateRequest>();
    }
}
