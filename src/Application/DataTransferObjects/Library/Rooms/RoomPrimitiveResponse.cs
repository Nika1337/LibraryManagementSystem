

namespace Nika1337.Library.Application.DataTransferObjects.Library.Rooms;

public record RoomPrimitiveResponse
{
    public required int Id { get; init; }
    public required string RoomNumber { get; init; }
}
