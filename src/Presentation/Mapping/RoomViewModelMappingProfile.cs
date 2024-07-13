using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Rooms;
using Nika1337.Library.Presentation.Models.Rooms;

namespace Nika1337.Library.Presentation.Mapping;

public class RoomViewModelMappingProfile : Profile
{
    public RoomViewModelMappingProfile()
    {
        CreateMap<RoomDetailedViewModel, RoomUpdateRequest>();
        
        CreateMap<RoomDetailedResponse, RoomDetailedViewModel>();

        CreateMap<RoomPreviewResponse, RoomPreviewViewModel>(); 

        CreateMap<RoomCreateViewModel, RoomCreateRequest>();
    }
}
