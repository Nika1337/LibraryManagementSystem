using Ardalis.Specification;
using Nika1337.Library.ApplicationCore.Entities;
using System.Linq;


namespace Nika1337.Library.Application.Specifications;

public class LanguageSpecification : SingleResultSpecification<Language>
{
    public LanguageSpecification(string name)
    {
        Query
            .Where(et => et.Name == name);
    }

    public LanguageSpecification(string name, int id)
    {
        Query
            .Where(et => et.Name == name && et.Id != id);
    }
}