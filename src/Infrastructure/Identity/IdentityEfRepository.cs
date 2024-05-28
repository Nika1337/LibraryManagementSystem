using Ardalis.Specification.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Abstractions;
namespace Nika1337.Library.Infrastructure.Identity;

internal class IdentityEfRepository<T>(IdentityContext dbContext) : RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : class
{

}

