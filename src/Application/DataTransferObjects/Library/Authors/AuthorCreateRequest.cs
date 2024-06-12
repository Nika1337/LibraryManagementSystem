
using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Authors;

public record AuthorCreateRequest
{
    public required string Name { get; init; }
    public required string Biography { get; init; }
    public required DateTime DateOfBirth { get; init; }
    public required bool IsAlive { get; init; }
}

