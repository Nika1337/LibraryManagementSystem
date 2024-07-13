

using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Rooms;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IRoomService : IBaseModelService
{
    Task<IEnumerable<RoomPrimitiveResponse>> GetActiveRoomsAsync();
    Task<PagedList<RoomPreviewResponse>> GetPagedRoomsAsync(BaseModelPagedRequest<Room> request);
    Task<RoomDetailedResponse> GetRoomAsync(int id);
    Task CreateRoomAsync(RoomCreateRequest request);
    Task UpdateRoomAsync(RoomUpdateRequest request);
}
