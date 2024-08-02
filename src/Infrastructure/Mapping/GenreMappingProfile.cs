using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Mapping;

public class GenreMappingProfile : Profile
{
    public GenreMappingProfile() 
    {
        CreateMap<GenreCreateRequest, Genre>();

        CreateMap<GenreUpdateRequest, Genre>();

        CreateMap<Genre, GenrePreviewResponse>(); 
       
        CreateMap<Genre, PrimitiveResponse>();
    }
}
