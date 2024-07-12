

namespace Nika1337.Library.Application.DataTransferObjects.Library.Rooms;

public record RoomCreateRequest
{
    public required int Floor { get; init; }
    public required string RoomNumber { get; init; }
    public required int? MaxCapacityOfPeople { get; init; }
}
