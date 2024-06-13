using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Presentation.Models.Authors;

namespace Nika1337.Library.Presentation.Mapping;

public class AuthorViewModelMappingProfile : Profile
{
    public AuthorViewModelMappingProfile()
    {
        CreateMap<AuthorDetailViewModel, AuthorUpdateRequest>();

        CreateMap<AuthorResponse, AuthorDetailViewModel>();

        CreateMap<AuthorResponse, AuthorViewModel>();

        CreateMap<AuthorCreateViewModel, AuthorCreateRequest>();
    }
}
