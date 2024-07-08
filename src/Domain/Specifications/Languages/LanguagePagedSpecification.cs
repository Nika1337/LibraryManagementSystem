using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System;
using System.Linq.Expressions;

namespace Nika1337.Library.Domain.Specifications.Languages;

public class LanguagePagedSpecification : BaseModelSpecification<Language>
{
    protected override Expression<Func<Language, string>>[] FieldSelectors => [language => language.Name];

    public LanguagePagedSpecification(BaseModelSpecificationParameters<Language> parameters) : base(parameters)
    {

    }
}
