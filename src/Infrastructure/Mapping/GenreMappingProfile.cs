using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Genres.Results;

namespace Nika1337.Library.Infrastructure.Mapping;

public class GenreMappingProfile : Profile
{
    public GenreMappingProfile() 
    {
        CreateMap<GenreCreateRequest, Genre>();

        CreateMap<GenreUpdateRequest, Genre>();

        CreateMap<GenreResult, GenrePreviewResponse>();

        CreateMap<GenreDetailedResult, GenreDetailedResponse>();

        CreateMap<Genre, PrimitiveResponse>();
    }
}
