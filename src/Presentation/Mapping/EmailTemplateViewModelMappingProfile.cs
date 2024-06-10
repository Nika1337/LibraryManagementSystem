using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.Presentation.Models.Operations;

namespace Nika1337.Library.Presentation.Mapping;

public class EmailTemplateViewModelMappingProfile : Profile
{
    public EmailTemplateViewModelMappingProfile()
    {
        CreateMap<EmailTemplateSimpleResponse, SimpleEmailTemplateViewModel>();

        CreateMap<EmailTemplateDetailedResponse, DetailedEmailTemplateViewModel>();

        CreateMap<DetailedEmailTemplateViewModel, EmailTemplateUpdateRequest>();

    }
}
