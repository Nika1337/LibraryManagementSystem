using Ardalis.Specification;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IRepository<T> : IRepositoryBase<T> where T : class 
{

}