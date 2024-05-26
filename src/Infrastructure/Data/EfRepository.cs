
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
namespace Nika1337.Library.Infrastructure.Data;

public class EfRepository<T>(DbContext dbContext) : LibraryRepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : BaseModel
{

}
