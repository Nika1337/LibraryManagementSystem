using Ardalis.Specification;
using Nika1337.Library.Domain.Entities;
using System.Linq;


namespace Nika1337.Library.Domain.Specifications.Languages;

public class LanguageByNameSpecification : SingleResultSpecification<Language>
{
    public LanguageByNameSpecification(string name)
    {
        Query.Where(et => et.Name == name);
    }
}