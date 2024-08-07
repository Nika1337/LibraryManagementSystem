
using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Publishers;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Publishers.Results;

namespace Nika1337.Library.Infrastructure.Mapping;

public class PublisherMappingProfile : Profile
{
    public PublisherMappingProfile()
    {
        CreateMap<PublisherCreateRequest, Publisher>();

        CreateMap<PublisherUpdateRequest, Publisher>();

        CreateMap<PublisherDetailedResult, PublisherDetailedResponse>();

        CreateMap<PublisherResult, PublisherPreviewResponse>();

        CreateMap<Publisher, PrimitiveResponse>()
            .ForMember(ppr => ppr.Name, opts => opts.MapFrom(p => p.PublisherName));
    }
}
