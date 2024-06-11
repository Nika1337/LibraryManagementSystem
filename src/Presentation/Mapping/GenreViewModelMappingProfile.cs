using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using Nika1337.Library.Presentation.Models.Genres;
namespace Nika1337.Library.Presentation.Mapping;

public class GenreViewModelMappingProfile : Profile
{
    public GenreViewModelMappingProfile()
    {
        CreateMap<GenreDetailViewModel, GenreUpdateRequest>();

        CreateMap<GenreResponse, GenreDetailViewModel>();

        CreateMap<GenreResponse, GenreViewModel>();

        CreateMap<GenreCreateViewModel, GenreCreateRequest>();
    }
}
