using Ardalis.Specification;

namespace Nika1337.Library.Domain.Abstractions;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{

}