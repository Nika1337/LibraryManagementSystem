using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.Presentation.Models.EmailTemplates;

namespace Nika1337.Library.Presentation.Mapping;

public class EmailTemplateViewModelMappingProfile : Profile
{
    public EmailTemplateViewModelMappingProfile()
    {
        CreateMap<EmailTemplateDetailedResponse, EmailTemplateDetailedViewModel>()
            .ForMember(detvm => detvm.ErrorMessage, opts => opts.Ignore());

        CreateMap<EmailTemplateDetailedViewModel, EmailTemplateUpdateRequest>();

        CreateMap<EmailTemplateSimpleResponse, EmailTemplatePreviewViewModel>();
    }
}
