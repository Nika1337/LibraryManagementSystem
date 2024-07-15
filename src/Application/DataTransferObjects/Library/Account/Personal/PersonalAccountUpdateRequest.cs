
using Nika1337.Library.Domain.Entities;
using System;

namespace Nika1337.Library.Application.DataTransferObjects.Library.Account.Personal;

public record PersonalAccountUpdateRequest : AccountUpdateRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required Gender Gender { get; init; }
    public required string IdNumber { get; init; }
    public required DateTime DateOfBirth { get; init; }
}
