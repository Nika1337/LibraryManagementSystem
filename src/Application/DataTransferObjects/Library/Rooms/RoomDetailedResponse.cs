﻿using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Rooms;

public record RoomDetailedResponse
{
    public required int Id { get; init; }
    public required int Floor { get; init; }
    public required string RoomNumber { get; init; }
    public required int? MaxCapacityOfPeople { get; init; }
    public required int BookshelfsCount { get; init; }
    public required DateTime? DeletedDate { get; init; }
}