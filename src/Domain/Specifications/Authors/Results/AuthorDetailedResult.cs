﻿using System;

namespace Nika1337.Library.Domain.Specifications.Authors.Results;

public class AuthorDetailedResult
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Biography { get; init; }
    public required DateTime DateOfBirth { get; init; }
    public required bool IsAlive { get; init; }
    public required DateTime? DeletedDate { get; init; }
}
