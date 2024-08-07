using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Presentation.Models.Authors;

namespace Nika1337.Library.Presentation.Mapping;

public class AuthorViewModelMappingProfile : Profile
{
    public AuthorViewModelMappingProfile()
    {
        CreateMap<AuthorDetailViewModel, AuthorUpdateRequest>();

        CreateMap<AuthorDetailedResponse, AuthorDetailViewModel>();

        CreateMap<AuthorPreviewResponse, AuthorPreviewViewModel>();

        CreateMap<AuthorCreateViewModel, AuthorCreateRequest>();
    }
}
