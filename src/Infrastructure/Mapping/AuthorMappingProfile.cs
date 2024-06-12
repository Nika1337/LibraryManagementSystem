using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Mapping;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<AuthorCreateRequest, Author>();

        CreateMap<AuthorUpdateRequest, Author>();

        CreateMap<Author, AuthorResponse>();
    }
}
