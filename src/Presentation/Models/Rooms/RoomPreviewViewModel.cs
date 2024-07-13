﻿

namespace Nika1337.Library.Presentation.Models.Rooms;

public class RoomPreviewViewModel
{
    public required int Id { get; init; }
    public required int Floor { get; init; }
    public required string RoomNumber { get; init; }
    public required int? MaxCapacityOfPeople { get; init; }
    public required int BookshelfCount { get; init; }
    public required bool IsActive { get; init; }
}
