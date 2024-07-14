using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Rooms;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Mapping;

public class RoomMappingProfile : Profile
{
    public RoomMappingProfile()
    {
        CreateMap<RoomCreateRequest, Room>();

        CreateMap<RoomUpdateRequest, Room>();

        CreateMap<Room, RoomDetailedResponse>()
            .ForMember(rdr => rdr.EditionsCount, opts => opts.MapFrom(r => r.Editions.Count));

        CreateMap<Room, RoomPreviewResponse>()
            .ForMember(rpr => rpr.EditionsCount, opts => opts.MapFrom(r => r.Editions.Count))
            .ForMember(rpr => rpr.IsActive, opts => opts.MapFrom(r => r.DeletedDate == null));
    }
}
