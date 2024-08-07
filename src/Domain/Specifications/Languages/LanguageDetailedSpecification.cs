

using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Languages.Results;

namespace Nika1337.Library.Domain.Specifications.Languages;

public class LanguageDetailedSpecification : BaseModelByIdSpecification<Language, LanguageDetailedResult>
{
    public LanguageDetailedSpecification(int id) : base(id)
    {
        Query.Select(language => new LanguageDetailedResult 
        { 
            Id = language.Id,
            Name = language.Name,
            DeletedDate = language.DeletedDate
        });
    }
}
