using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications.Languages.Results;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Languages;

public class LanguagesSpecification : BaseModelsSpecification<Language, LanguageResult>
{
    protected override Expression<Func<Language, string>>[] FieldSelectors => [language => language.Name];

    public LanguagesSpecification(BaseModelSpecificationParameters<Language> parameters) : base(parameters)
    {
        Query.Select(language => new LanguageResult
        {
            Id = language.Id,
            Name = language.Name,
            IsActive = language.DeletedDate == null
        });
    }
}
