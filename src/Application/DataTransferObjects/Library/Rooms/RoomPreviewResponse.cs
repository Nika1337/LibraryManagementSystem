


namespace Nika1337.Library.Application.DataTransferObjects.Library.Rooms;


public record RoomPreviewResponse
{
    public required int Id { get; init; }
    public required int Floor { get; init; }
    public required string RoomNumber { get; init; }
    public required int? MaxCapacityOfPeople { get; init; }
    public required int EditionsCount { get; init; }
    public required bool IsActive { get; init; }
}