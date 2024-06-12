namespace Nika1337.Library.Domain.Exceptions;

public class GenreNotFoundException : NotFoundException
{
    public GenreNotFoundException(int id) : base($"No Genre found with id '{id}'")
    {
    }
}