
using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System;
using System.Linq;

namespace Nika1337.Library.Infrastructure.Mapping;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<IdentityEmployee, EmployeeSimpleResponse>()
            .ForMember(esp => esp.Username, opts => opts.MapFrom(ie => ie.UserName))
            .ForMember(esp => esp.IsActive, opts => opts.MapFrom(ie => ie.TerminationDate == null));

        CreateMap<IdentityEmployee, EmployeeDetailedResponse>()
            .ForMember(edp => edp.Username, opts => opts.MapFrom(ie => ie.UserName))
            .ForMember(edp => edp.Address, opts => opts.MapFrom(ie => ie.Address ?? new Address()))
            .ForMember(
                ie => ie.RoleNames,
                opts => opts.MapFrom(edp => edp.Roles.Select(junction => junction.Role.Name))
            );


        CreateMap<EmployeeRegistrationRequest, IdentityEmployee>()
            .ForMember(ie => ie.Roles, opts => opts.Ignore())
            .ForMember(ie => ie.UserName, opts => opts.MapFrom(esp => esp.Username))
            .ForMember(ie => ie.StartDate, opts => opts.MapFrom(esp => DateTime.UtcNow));


        CreateMap<EmployeeManagerUpdateRequest, IdentityEmployee>()
            .ForMember(ie => ie.Roles, opts => opts.Ignore());

        CreateMap<EmployeeAccountUpdateRequest, IdentityEmployee>();

        CreateMap<EmployeeUpdateRequest, IdentityEmployee>()
            .Include<EmployeeManagerUpdateRequest, IdentityEmployee>()
            .Include<EmployeeAccountUpdateRequest, IdentityEmployee>();


    }
}
