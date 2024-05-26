using Ardalis.Specification;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : BaseModel
{

}