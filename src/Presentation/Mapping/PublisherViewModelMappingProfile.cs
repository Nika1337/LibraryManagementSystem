

using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Publishers;
using Nika1337.Library.Presentation.Models.Publishers;

namespace Nika1337.Library.Presentation.Mapping;

public class PublisherViewModelMappingProfile : Profile
{
    public PublisherViewModelMappingProfile()
    {
        CreateMap<PublisherDetailedViewModel, PublisherUpdateRequest>();

        CreateMap<PublisherDetailedResponse, PublisherDetailedViewModel>();

        CreateMap<PublisherPreviewResponse, PublisherPreviewViewModel>();

        CreateMap<PublisherCreateViewModel, PublisherCreateRequest>();
    }
}
