

namespace Nika1337.Library.Domain.Exceptions;

public class AuthorNotFoundException : NotFoundException
{
    public AuthorNotFoundException(int id) : base($"No author found with id '{id}'")
    {

    }
}
