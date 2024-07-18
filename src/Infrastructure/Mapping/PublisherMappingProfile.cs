
using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Publishers;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Mapping;

public class PublisherMappingProfile : Profile
{
    public PublisherMappingProfile()
    {
        CreateMap<PublisherCreateRequest, Publisher>();

        CreateMap<PublisherUpdateRequest, Publisher>();

        CreateMap<Publisher, PublisherDetailedResponse>()
            .ForMember(pdr => pdr.PublishedBookEditionsCount, opts => opts.MapFrom(p => p.PublishedBookEditions.Count));

        CreateMap<Publisher, PublisherPreviewResponse>()
            .ForMember(pdr => pdr.PublishedBookEditionsCount, opts => opts.MapFrom(r => r.PublishedBookEditions.Count))
            .ForMember(ppr => ppr.IsActive, opts => opts.MapFrom(r => r.DeletedDate == null));

        CreateMap<Publisher, PublisherPrimitiveResponse>()
            .ForMember(ppr => ppr.Name, opts => opts.MapFrom(p => p.PublisherName));
    }
}
