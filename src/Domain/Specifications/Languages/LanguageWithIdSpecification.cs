using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Domain.Specifications.Languages;

public class LanguageWithIdSpecification : SingleResultSpecification<Language>
{
    public LanguageWithIdSpecification(int id)
    {
        Query.Where(language => language.Id == id);
    }
}
