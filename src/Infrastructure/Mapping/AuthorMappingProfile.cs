using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Authors;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Authors.Results;

namespace Nika1337.Library.Infrastructure.Mapping;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<AuthorCreateRequest, Author>();

        CreateMap<AuthorUpdateRequest, Author>();

        CreateMap<AuthorResult, AuthorPreviewResponse>();

        CreateMap<AuthorDetailedResult, AuthorDetailedResponse>();

        CreateMap<Author, PrimitiveResponse>();
    }
}
