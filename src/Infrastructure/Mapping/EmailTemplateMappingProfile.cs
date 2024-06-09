

using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.Infrastructure.Mapping;

public class EmailTemplateMappingProfile : Profile
{
    public EmailTemplateMappingProfile() 
    {
        CreateMap<EmailTemplate, EmailTemplateSimpleResponse>()
            .ForMember(
                et => et.IsActive,
                opts => opts.MapFrom(et => et.DeletedDate == null)
            );

        CreateMap<EmailTemplate, EmailTemplateDetailedResponse>();

        CreateMap<EmailTemplateUpdateRequest, EmailTemplate>();
    }
}
