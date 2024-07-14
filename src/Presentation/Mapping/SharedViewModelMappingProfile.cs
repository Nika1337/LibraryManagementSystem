using AutoMapper;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Presentation.Models.Shared;

namespace Nika1337.Library.Presentation.Mapping;

public class SharedViewModelMappingProfile : Profile
{
    public SharedViewModelMappingProfile()
    {
        CreateMap<ContactInformation, ContactInformationViewModel>()
            .ReverseMap();

        CreateMap<Address, AddressViewModel>()
            .ReverseMap();
    }
}
