using Ardalis.Specification;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.ApplicationCore.Abstractions;

public interface IRepository<T> : IRepositoryBase<T> where T : BaseModel {

}