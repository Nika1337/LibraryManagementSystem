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
            .ForMember(rdr => rdr.BookshelfsCount, opts => opts.MapFrom(r => r.Bookshelves.Count));

        CreateMap<Room, RoomPreviewResponse>()
            .ForMember(rpr => rpr.BookshelfsCount, opts => opts.MapFrom(r => r.Bookshelves.Count));
    }
}
