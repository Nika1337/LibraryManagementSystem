using Ardalis.Specification;

namespace Nika1337.Library.Domain.Abstractions;

public interface IRepository<T> : IRepositoryBase<T> where T : class 
{

}