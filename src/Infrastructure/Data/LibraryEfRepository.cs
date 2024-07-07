using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Threading;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Data;

internal class LibraryEfRepository<T>(LibraryContext dbContext) : RepositoryBase<T>(dbContext), IRepository<T> where T : BaseModel
{
    public async Task<PagedList<T>> PagedListAsync(ISpecification<T> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        var entities = await base.ListAsync(specification, cancellationToken);

        return PagedList<T>.ToPagedList(entities, pageNumber, pageSize);
    }
}

