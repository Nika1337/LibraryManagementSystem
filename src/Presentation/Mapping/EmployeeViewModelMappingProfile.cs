

using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.Presentation.Models.EmployeeManagement;

namespace Nika1337.Library.Presentation.Mapping;

public class EmployeeViewModelMappingProfile : Profile
{
    public EmployeeViewModelMappingProfile()
    {
        CreateMap<EmployeeSimpleResponse, EmployeeViewModel>();

        CreateMap<EmployeeDetailedResponse, EmployeeProfileViewModel>()
            .ForMember(epvm => epvm.SelectedRoles, opts => opts.MapFrom(edr => edr.RoleNames))
            .ForMember(epvm => epvm.Country, opts => opts.MapFrom(edr => edr.Address.Country))
            .ForMember(epvm => epvm.State, opts => opts.MapFrom(edr => edr.Address.State))
            .ForMember(epvm => epvm.City, opts => opts.MapFrom(edr => edr.Address.City))
            .ForMember(epvm => epvm.Street, opts => opts.MapFrom(edr => edr.Address.Street))
            .ForMember(epvm => epvm.PostalCode, opts => opts.MapFrom(edr => edr.Address.PostalCode))
            .ForMember(epvm => epvm.ErrorMessage, opts => opts.Ignore())
            .ForMember(epvm => epvm.AvailableRoles, opts => opts.Ignore());
    }
}
