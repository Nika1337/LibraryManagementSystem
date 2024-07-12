

namespace Nika1337.Library.Application.DataTransferObjects.Library.Rooms;

public record RoomUpdateRequest
{
    public required int Id { get; init; }
    public required string RoomNumber { get; init; }
    public required int? MaxCapacityOfPeople { get; init; }
}
