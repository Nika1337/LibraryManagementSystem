using System;

namespace Nika1337.Library.Domain.Specifications.Rooms.Results;

public class RoomDetailedResult
{
    public required int Id { get; init; }
    public required int Floor { get; init; }
    public required string RoomNumber { get; init; }
    public required int? MaxCapacityOfPeople { get; init; }
    public required int EditionsCount { get; init; }
    public required DateTime? DeletedDate { get; init; }
}
