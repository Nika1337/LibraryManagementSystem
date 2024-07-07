using Ardalis.Specification;
using Nika1337.Library.Domain.RequestFeatures;
using System.Threading.Tasks;
using System.Threading;

namespace Nika1337.Library.Domain.Abstractions;

public interface IRepository<T> : IRepositoryBase<T> where T : class 
{
    Task<PagedList<T>> PagedListAsync(ISpecification<T> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default);
}