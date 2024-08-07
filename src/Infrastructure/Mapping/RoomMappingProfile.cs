using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Rooms;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Rooms.Results;

namespace Nika1337.Library.Infrastructure.Mapping;

public class RoomMappingProfile : Profile
{
    public RoomMappingProfile()
    {
        CreateMap<RoomCreateRequest, Room>();

        CreateMap<RoomUpdateRequest, Room>();

        CreateMap<RoomDetailedResult, RoomDetailedResponse>();

        CreateMap<RoomResult, RoomPreviewResponse>();

        CreateMap<Room, PrimitiveResponse>()
            .ForMember(rpr => rpr.Name, opts => opts.MapFrom(r => r.RoomNumber));
    }
}
