using System;

namespace Nika1337.Library.Domain.Specifications.Languages.Results;

public class LanguageDetailedResult
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required DateTime? DeletedDate { get; init; }
}
