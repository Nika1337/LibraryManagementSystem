

namespace Nika1337.Library.ApplicationCore.Exceptions;

public class GenreNotFoundException : NotFoundException
{
    public GenreNotFoundException(int id) : base($"No Genre found with id '{id}'")
    {
    }
}
