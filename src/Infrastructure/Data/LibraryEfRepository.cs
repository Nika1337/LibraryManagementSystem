using Ardalis.Specification.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.Infrastructure.Data;

internal class LibraryEfRepository<T>(LibraryContext dbContext) : RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : BaseModel
{

}

